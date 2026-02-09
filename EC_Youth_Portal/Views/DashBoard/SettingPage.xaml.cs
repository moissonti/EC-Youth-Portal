using EC_Youth_Portal.ViewModel;

namespace EC_Youth_Portal.Views.DashBoard;

public partial class SettingPage : ContentPage
{
	public SettingPage(PreferencesViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}