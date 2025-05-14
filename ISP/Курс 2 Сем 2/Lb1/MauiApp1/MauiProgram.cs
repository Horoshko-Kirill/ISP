using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace MauiApp1;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});


        builder.Services.AddSingleton<IDbService, SQLiteService>();

        //builder.Services.AddSingleton<IRateService, RateService>();


        builder.Services.AddHttpClient<IRateService, RateService>("NBRB", client =>
        {
            client.BaseAddress = new Uri("https://api.nbrb.by/exrates/rates");
            client.Timeout = TimeSpan.FromSeconds(15);
        });

		builder.Services.AddTransient<ConvertPage>();


#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
