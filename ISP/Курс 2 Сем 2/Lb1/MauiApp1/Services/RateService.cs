using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

public class RateService : IRateService
{
    private readonly HttpClient _httpClient;
    private readonly string[] _targetCurrencies = { "RUB", "EUR", "USD", "CHF", "CNY", "GBP" };

    public RateService(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        //_httpClient.BaseAddress = new Uri("https://api.nbrb.by/");
       // _httpClient.Timeout = TimeSpan.FromSeconds(15);
    }

    public async Task<IEnumerable<Rate>> GetRatesAsync(DateTime date)
    {
        try
        {
            var allRates = await GetAllRatesForDateAsync(date);

            if (allRates == null || !allRates.Any())
            {
                Console.WriteLine("No rates received from API");
                return Enumerable.Empty<Rate>();
            }

            var filteredRates = allRates
                .Where(r => r != null &&
                      r.Cur_Abbreviation != null &&
                      _targetCurrencies.Contains(r.Cur_Abbreviation))
                .ToList();

           
            filteredRates.Add(new Rate
            {
                Cur_ID = 0,
                Date = date,
                Cur_Abbreviation = "BYN",
                Cur_Scale = 1,
                Cur_Name = "Белорусский рубль",
                Cur_OfficialRate = 1
            });

            Console.WriteLine($"Successfully loaded {filteredRates.Count} rates");
            return filteredRates;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in GetRatesAsync: {ex}");
            return Enumerable.Empty<Rate>();
        }
    }

    private async Task<List<Rate>> GetAllRatesForDateAsync(DateTime date)
    {
        try
        {
            var url = $"?ondate={date:yyyy-MM-dd}&periodicity=0";
            Debug.WriteLine($"Requesting URL: {url}");

            var response = await _httpClient.GetAsync(url);

            Console.WriteLine($"Response status: {response.StatusCode}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Raw response: {content}");

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Converters = { new JsonStringEnumConverter() }
            };

            var rates = JsonSerializer.Deserialize<List<Rate>>(content, options);
            Console.WriteLine($"Deserialized {rates?.Count ?? 0} rates");

            return rates ?? new List<Rate>();
        }
        catch (TaskCanceledException)
        {
            Debug.WriteLine("Request timeout");
            return new List<Rate>();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error in GetAllRatesForDateAsync: {ex}");
            return new List<Rate>();
        }
    }
}