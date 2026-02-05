using EC_Youth_Portal.ViewModel;

namespace EC_Youth_Portal.Views.DashBoard;

public partial class MyProfilePage : ContentPage
{
	public MyProfilePage(MyProfilePageViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}