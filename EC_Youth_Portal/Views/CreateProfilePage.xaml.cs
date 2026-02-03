using EC_Youth_Portal.ViewModel;

namespace EC_Youth_Portal.Views;

public partial class CreateProfilePage : ContentPage
{
    public CreateProfilePage(CreateProfilePageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}