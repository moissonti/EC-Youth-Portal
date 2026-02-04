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

            // Registered Pages
            builder.Services.AddTransient<Views.CreateProfilePage>();
            builder.Services.AddTransient<Views.RegisterPage>();
            builder.Services.AddTransient<Views.LoginPage>();
            builder.Services.AddTransient<Views.MainPage>();

            builder.Services.AddTransient<Views.DashBoard.DashboardLandingPage>();
            builder.Services.AddTransient<Views.DashBoard.Y2RPage>();
            builder.Services.AddTransient<Views.DashBoard.MyApplicationsPage>();
            builder.Services.AddTransient<Views.DashBoard.PathwayBuilderPage>();
            builder.Services.AddTransient<Views.DashBoard.TrackPage>();

            // Registered ViewModels
            builder.Services.AddTransient<ViewModel.RegisterPageViewModel>();
            builder.Services.AddTransient<ViewModel.CreateProfilePageViewModel>();
            builder.Services.AddTransient<ViewModel.MainPageViewModel>();
            builder.Services.AddTransient<ViewModel.DashboardLandingPageViewModel>();
            builder.Services.AddTransient<ViewModel.LoginPageViewModel>();


            return builder.Build();
        }
    }
}
