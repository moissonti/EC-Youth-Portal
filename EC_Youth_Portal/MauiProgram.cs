using Microsoft.Extensions.Logging;

namespace EC_Youth_Portal
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

            // Register Pages
            builder.Services.AddTransient<Views.CreateProfilePage>();
            builder.Services.AddTransient<Views.RegisterPage>();
            builder.Services.AddTransient<Views.LoginPage>();
            builder.Services.AddTransient<Views.MainPage>();

            // Register ViewModels
            builder.Services.AddTransient<ViewModel.RegisterPageViewModel>();
            builder.Services.AddTransient<ViewModel.CreateProfilePageViewModel>();
            builder.Services.AddTransient<ViewModel.MainPageViewModel>();


            return builder.Build();
        }
    }
}
