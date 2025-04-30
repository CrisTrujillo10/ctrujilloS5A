using Microsoft.Extensions.Logging;

namespace ctrujilloS5A
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
            string dbPath = FileAccessHelper.GetLocalFolderPath("personas.db");
            builder.Services.AddSingleton<Repository.PersonRepository>
                (s => ActivatorUtilities.CreateInstance<Repository.PersonRepository>
                (s,dbPath));

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
