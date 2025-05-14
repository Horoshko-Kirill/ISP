namespace MauiApp1;

public partial class ConvertPage : ContentPage
{

    private readonly IRateService _rateService;
    private IEnumerable<Rate> _currentRates = Enumerable.Empty<Rate>();

    public ConvertPage(IRateService rateService)
    {
        InitializeComponent();
        _rateService = rateService;

        
        Dispatcher.Dispatch(async () => {
            await LoadRates(DateTime.Today);
        });
    }

    private async Task LoadRates(DateTime date)
    {
        try
        {
            IsBusy = true;
            resultLabel.Text = "Загрузка данных...";

            _currentRates = await _rateService.GetRatesAsync(date);
            var ratesList = _currentRates?.ToList() ?? new List<Rate>();

            if (!ratesList.Any())
            {
                resultLabel.Text = "Данные не получены";
                return;
            }


            MainThread.BeginInvokeOnMainThread(() =>
            {
                
                fromCurrencyPicker.ItemsSource = ratesList;
                toCurrencyPicker.ItemsSource = ratesList;

            
                fromCurrencyPicker.ItemDisplayBinding = new Binding("Cur_Abbreviation");
                toCurrencyPicker.ItemDisplayBinding = new Binding("Cur_Abbreviation");

             
                var bynIndex = ratesList.FindIndex(r => r.Cur_Abbreviation == "BYN");
                var usdIndex = ratesList.FindIndex(r => r.Cur_Abbreviation == "USD");

                fromCurrencyPicker.SelectedIndex = bynIndex >= 0 ? bynIndex : 0;
                toCurrencyPicker.SelectedIndex = usdIndex >= 0 ? usdIndex : 0;

                ratesCollectionView.ItemsSource = ratesList.Where(r => r.Cur_Abbreviation != "BYN");
                resultLabel.Text = "Готово к конвертации";
            });
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ошибка", $"Ошибка загрузки: {ex.Message}", "OK");
            resultLabel.Text = "Ошибка загрузки данных";
        }
        finally
        {
            IsBusy = false;
        }
    }
    private void OnDateSelected(object sender, DateChangedEventArgs e)
    {
        LoadRates(e.NewDate);
    }

    private void OnConvertClicked(object sender, EventArgs e)
    {
        if (!decimal.TryParse(amountEntry.Text, out var amount) || amount <= 0)
        {
            resultLabel.Text = "Введите корректную сумму";
            return;
        }

        if (fromCurrencyPicker.SelectedItem is not Rate fromRate ||
            toCurrencyPicker.SelectedItem is not Rate toRate)
        {
            resultLabel.Text = "Выберите валюты";
            return;
        }

        if (fromRate.Cur_OfficialRate == null || toRate.Cur_OfficialRate == null)
        {
            resultLabel.Text = "Курс для выбранной валюты недоступен";
            return;
        }

        try
        {
            decimal result = fromRate.Cur_Abbreviation switch
            {
                "BYN" => amount / (toRate.Cur_OfficialRate.Value / toRate.Cur_Scale),
                _ when toRate.Cur_Abbreviation == "BYN" => amount * (fromRate.Cur_OfficialRate.Value / fromRate.Cur_Scale),
                _ => (amount * (fromRate.Cur_OfficialRate.Value / fromRate.Cur_Scale))
                       / (toRate.Cur_OfficialRate.Value / toRate.Cur_Scale)
            };

            resultLabel.Text = $"{amount:N2} {fromRate.Cur_Abbreviation} = {result:N2} {toRate.Cur_Abbreviation}";
        }
        catch (Exception ex)
        {
            resultLabel.Text = $"Ошибка конвертации: {ex.Message}";
        }
    }
}
