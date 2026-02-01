using EC_Youth_Portal.ViewModel;

namespace EC_Youth_Portal.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        // Bind ViewModel to the View
        BindingContext = new MainPageViewModel();

    }
}
