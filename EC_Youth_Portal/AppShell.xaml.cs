using EC_Youth_Portal.Views;
using EC_Youth_Portal.Views.DashBoard;

namespace EC_Youth_Portal
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("CreateProfilePage", typeof(CreateProfilePage));

            Routing.RegisterRoute("DashboardLandingPage", typeof(DashboardLandingPage));

        }
    }
}
