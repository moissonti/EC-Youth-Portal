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
            Routing.RegisterRoute("EditProfilePage", typeof(EditProfilePage)); 
             Routing.RegisterRoute("AccountInformationPage", typeof(AccountInformationPage));
                Routing.RegisterRoute("ApplyOpportunityPage", typeof(ApplyOpportunityPage));
        }
    }
}
