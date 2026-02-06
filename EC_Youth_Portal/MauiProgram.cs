using EC_Youth_Portal.ViewModel;
using EC_Youth_Portal.Views.DashBoard;
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

            // Authentication Pages
            builder.Services.AddTransient<Views.CreateProfilePage>();
            builder.Services.AddTransient<Views.RegisterPage>();
            builder.Services.AddTransient<Views.LoginPage>();
            builder.Services.AddTransient<Views.MainPage>();

            // Dashboard Pages
            builder.Services.AddTransient<Views.DashBoard.DashboardLandingPage>();
            builder.Services.AddTransient<Views.DashBoard.Y2RPage>();
            builder.Services.AddTransient<Views.DashBoard.MyApplicationsPage>();
            builder.Services.AddTransient<Views.DashBoard.PathwayBuilderPage>();
            builder.Services.AddTransient<Views.DashBoard.MyProfilePage>();
            builder.Services.AddTransient<Views.DashBoard.AccountInformationPage>();
            builder.Services.AddTransient<Views.DashBoard.ApplyOpportunityPage>();


            // Authentication ViewModels
            builder.Services.AddTransient<ViewModel.RegisterPageViewModel>();
            builder.Services.AddTransient<ViewModel.MainPageViewModel>();
            builder.Services.AddTransient<ViewModel.LoginPageViewModel>();
            builder.Services.AddTransient<ViewModel.CreateProfilePageViewModel>();

            // DasBoard ViewModels
            builder.Services.AddTransient<ViewModel.DashboardLandingPageViewModel>();
            builder.Services.AddTransient<ViewModel.MyProfilePageViewModel>();
            builder.Services.AddTransient<ViewModel.PersonalInfoSectionViewModel>();
            builder.Services.AddTransient<ViewModel.EducationSectionViewModel>();
            builder.Services.AddTransient<ViewModel.SkillsSectionViewModel>();
            builder.Services.AddTransient<ViewModel.DocumentsSectionViewModel>(); 
            builder.Services.AddTransient<ViewModel.EditProfilePageViewModel>();
            builder.Services.AddTransient<ViewModel.AccountInformationPageViewModel>();
            builder.Services.AddTransient<ViewModel.ApplyOpportunityPageViewModel>();



            return builder.Build();
        }
    }
}
