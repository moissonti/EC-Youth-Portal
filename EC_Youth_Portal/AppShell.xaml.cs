using EC_Youth_Portal.Views;

namespace EC_Youth_Portal
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();


            Routing.RegisterRoute(nameof(Views.SplashPage), typeof(Views.SplashPage));
            Routing.RegisterRoute(nameof(Views.MainPage), typeof(Views.MainPage));
           
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
 
            Routing.RegisterRoute(nameof(CreateProfilePage), typeof(CreateProfilePage));

        }
    }
}
