using Microsoft.Extensions.Logging;

namespace LabelBug
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.ConfigureMauiHandlers(handlers =>
            {
#if ANDROID
                LabelBug.Platforms.Android.AndroidHelpers.AllowMultiLineTruncation();
#elif IOS
                LabelBug.Platforms.iOS.IosHelpers.AllowMultiLineTruncation();
#endif
            });

                return builder.Build();
        }
    }
}
