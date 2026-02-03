using EC_Youth_Portal.ViewModel;

namespace EC_Youth_Portal.Views;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();

        if (BindingContext is RegisterPageViewModel vm)
        {
            vm.SetView(this); // Pass View Reference to ViewModel
        }
    }
}