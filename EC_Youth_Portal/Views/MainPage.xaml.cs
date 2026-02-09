using EC_Youth_Portal.ViewModel;

namespace EC_Youth_Portal.Views;

public partial class MainPage : ContentPage
{
    public MainPage(MainPageViewModel viewModel)
    {
        InitializeComponent();

        //    // Bind the indicator view to the carousel
        carouselIndicator.SetBinding(IndicatorView.ItemsSourceProperty, "CarouselItems");
        carouselIndicator.SetBinding(IndicatorView.PositionProperty, "CurrentCarouselPosition");

        // Bind ViewModel to the View
        BindingContext = viewModel;

    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        if (BindingContext is MainPageViewModel viewModel)
        {
            viewModel.StopCarouselAutoScroll();
        }
    }
}
