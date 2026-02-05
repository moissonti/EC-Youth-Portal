
using EC_Youth_Portal.ViewModel;

namespace EC_Youth_Portal.Views.DashBoard;

public partial class EditProfilePage : ContentPage
{
	public EditProfilePage(EditProfilePageViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}