using EC_Youth_Portal.Views;
using EC_Youth_Portal.Views.DashBoard;

namespace EC_Youth_Portal
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Authentication Routes
            Routing.RegisterRoute("LoginPage", typeof(LoginPage));
            Routing.RegisterRoute("RegisterPage", typeof(RegisterPage));

            // Profile Routes
            Routing.RegisterRoute("CreateProfilePage", typeof(CreateProfilePage));

            // DashbBoard Routes
            Routing.RegisterRoute("EditProfilePage", typeof(EditProfilePage)); 
            Routing.RegisterRoute("AccountInformationPage", typeof(AccountInformationPage));
            Routing.RegisterRoute("SettingsPage", typeof(SettingPage));
            Routing.RegisterRoute("ApplyOpportunityPage", typeof(ApplyOpportunityPage));

        }
    }
}
