using EC_Youth_Portal.ViewModel;

namespace EC_Youth_Portal.Views.DashBoard;

public partial class AccountInformationPage : ContentPage
{
	public AccountInformationPage(AccountInformationPageViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}