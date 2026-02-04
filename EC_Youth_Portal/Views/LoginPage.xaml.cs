using EC_Youth_Portal.ViewModel;

namespace EC_Youth_Portal.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginPageViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
    }
}