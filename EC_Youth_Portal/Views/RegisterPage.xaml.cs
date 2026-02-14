using EC_Youth_Portal.ViewModel;

namespace EC_Youth_Portal.Views;

public partial class RegisterPage : ContentPage
{
    private RegisterPageViewModel _viewModel;

    public RegisterPage()
    {
        InitializeComponent();

        _viewModel = new RegisterPageViewModel();
        BindingContext = _viewModel;

        _viewModel.SetView(this);
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//MainPage");
    }
}