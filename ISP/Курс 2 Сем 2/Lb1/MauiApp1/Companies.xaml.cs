namespace MauiApp1;

public partial class Companies : ContentPage
{
    private readonly IDbService _dbService;
    public Companies(IDbService dbService)
	{
		InitializeComponent();
        _dbService = dbService;
        LoadCompanies();
        companyPicker.SelectedIndexChanged += OnCompanySelected;
    }

    private void LoadCompanies()
    {
        var companies = _dbService.GetAllCompany().ToList();
        companyPicker.ItemsSource = companies;
    }

    private void OnCompanySelected(object sender, EventArgs e)
    {
        if (companyPicker.SelectedItem is Company selectedCompany)
        {
            LoadTransports(selectedCompany.Id);
        }
    }

    private void LoadTransports(int companyId)
    {
        var transports = _dbService.GetTransportsMembers(companyId).ToList();

        var transportDisplay = transports.Select(t => new
        {
            t.Name,
            t.Photo,
        }).ToList();

        transportsCollection.ItemsSource = transportDisplay;
    }

}