namespace MauiApp1
{
    public partial class App : Application
    {
        public App(IDbService dbService)
        {
            InitializeComponent();

            dbService.Init();

            MainPage = new AppShell();
        }


    }
}