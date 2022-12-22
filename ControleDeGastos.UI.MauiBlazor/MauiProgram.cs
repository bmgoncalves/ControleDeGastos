using ControleDeGastos.UI.MauiBlazor.Data;
using Microsoft.Extensions.Logging;
namespace ControleDeGastos.UI.MauiBlazor
{
    public static class MauiProgram
    {
        //internal const string BaseAddress = "http://localhost:6400/";
        //internal const string ProdBaseAddress = "http://localhost:5000/";
        public static MauiApp CreateMauiApp()
        {
            //private readonly HttpClient cliente = new();
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<WeatherForecastService>();

            builder.Services.AddSingleton(new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5159/api/")
            });

            return builder.Build();
        }
    }
}