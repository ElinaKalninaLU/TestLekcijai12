using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace TestLekcijai12
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

            var config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .Build();

            builder.Configuration.AddConfiguration(config);
            builder.Services.AddSingleton<IConfiguration>(config);
            builder.Services.AddTransient<ViewModel.IRectangleViewModel, ViewModel.RectangleViewModel>();
//            builder.Services.AddTransient<ViewModel.IRectangleViewModel,ViewModel.RectangleSQLiteViewModel>();
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<RectanglePage>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
