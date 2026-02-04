namespace EC_Youth_Portal.Views.DashBoard;
using EC_Youth_Portal.ViewModel;

public partial class DashboardLandingPage : ContentPage
{
	public DashboardLandingPage(DashboardLandingPageViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}