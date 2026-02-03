using EC_Youth_Portal.ViewModel;

namespace EC_Youth_Portal.Views;

public partial class MainPage : ContentPage
{
    public MainPage(MainPageViewModel viewModel)
    {
        InitializeComponent();

        // Bind ViewModel to the View
        BindingContext = viewModel;

    }
}
