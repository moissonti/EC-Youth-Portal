using EC_Youth_Portal.Views;

namespace EC_Youth_Portal
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();


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