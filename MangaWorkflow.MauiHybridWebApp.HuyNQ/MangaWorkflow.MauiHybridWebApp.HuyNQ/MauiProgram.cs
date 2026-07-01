using Microsoft.Extensions.Logging;
using MangaWorkflow.MauiHybridWebApp.HuyNQ.Shared.Services;
using MangaWorkflow.MauiHybridWebApp.HuyNQ.Services;

namespace MangaWorkflow.MauiHybridWebApp.HuyNQ;

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

        // Add device-specific services used by the MangaWorkflow.MauiHybridWebApp.HuyNQ.Shared project
        builder.Services.AddSingleton<IFormFactor, FormFactor>();

        builder.Services.AddMauiBlazorWebView();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
