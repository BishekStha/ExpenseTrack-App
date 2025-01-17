using ExpenseTrack.Components;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace ExpenseTrack
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

            if (!Directory.Exists(Utils.ROOTFOLDER))
            {
                Directory.CreateDirectory(Utils.ROOTFOLDER);
            }
            if (!File.Exists(Utils.TRANSACTIONS))
            {
                File.Create(Utils.TRANSACTIONS);
            }

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}