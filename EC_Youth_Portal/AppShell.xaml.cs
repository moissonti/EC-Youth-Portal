using EC_Youth_Portal.Views;

namespace EC_Youth_Portal
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(CreateProfilePage), typeof(CreateProfilePage));

        }
    }
}
