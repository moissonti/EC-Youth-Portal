using EC_Youth_Portal.Views;

namespace EC_Youth_Portal
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Set SplashScreen as the initial page with NavigationPage
            // This allows for smooth navigation between pages
            MainPage = new NavigationPage(new SplashPage())
            {
                // Customize the navigation bar to match your brand
                BarBackgroundColor = Color.FromArgb("#1E3A5F"), // Navy Blue
                BarTextColor = Colors.White
            };

        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = base.CreateWindow(activationState);

            // Optional: Set window properties
            window.Title = "Eastern Cape Opportunities";

            return window;
        }
    }
}