﻿using Microsoft.Extensions.Logging;
using MonAppBlazor.Services;

namespace MonAppBlazor.Mobile
{
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
                });

            builder.Services.AddMauiBlazorWebView();

            builder.Services.AddHttpClient("Api", config =>
            {
                config.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
                config.BaseAddress = new Uri("https://localhost:7038/");
            });

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<WeatherForecastService>();
            builder.Services.AddScoped<ProduitsService>();
            return builder.Build();
        }
    }
}
