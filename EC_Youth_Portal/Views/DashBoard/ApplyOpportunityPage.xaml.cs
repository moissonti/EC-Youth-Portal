using EC_Youth_Portal.ViewModel;

namespace EC_Youth_Portal.Views.DashBoard;

public partial class ApplyOpportunityPage : ContentPage
{
	public ApplyOpportunityPage(ApplyOpportunityPageViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}