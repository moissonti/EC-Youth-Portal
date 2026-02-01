namespace EC_Youth_Portal.Views;

public partial class SplashPage : ContentPage
{
	public SplashPage()
	{
		InitializeComponent();
	}

	protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Start animations
            await AnimateSplashScreen();

            // Navigate to MainPage after animations
            await Task.Delay(2000); // Additional delay before navigation
            await Shell.Current.GoToAsync("//MainPage");
    }

        private async Task AnimateSplashScreen()
        {
            // Initial state
            LogoFrame.Scale = 0;
            TitleContainer.Opacity = 0;
            Tagline.Opacity = 0;
            LoadingContainer.Opacity = 0;

            // Animate Logo entrance
            await LogoFrame.ScaleTo(1, 600, Easing.SpringOut);

            // Animate Title fade in
            await TitleContainer.FadeTo(1, 800, Easing.CubicIn);

            // Animate Tagline
            await Tagline.FadeTo(0.7, 500, Easing.Linear);

            // Show loading indicator
            await LoadingContainer.FadeTo(1, 400, Easing.Linear);

            // Animate loading dots
            AnimateLoadingDots();
        }

        private async void AnimateLoadingDots()
        {
            while (true)
            {
                await Task.WhenAll(
                    Dot1.ScaleTo(1.3, 400, Easing.CubicInOut),
                    Dot1.FadeTo(0.3, 400, Easing.CubicInOut)
                );
                await Task.WhenAll(
                    Dot1.ScaleTo(1, 400, Easing.CubicInOut),
                    Dot1.FadeTo(1, 400, Easing.CubicInOut)
                );

                await Task.WhenAll(
                    Dot2.ScaleTo(1.3, 400, Easing.CubicInOut),
                    Dot2.FadeTo(0.3, 400, Easing.CubicInOut)
                );
                await Task.WhenAll(
                    Dot2.ScaleTo(1, 400, Easing.CubicInOut),
                    Dot2.FadeTo(1, 400, Easing.CubicInOut)
                );

                await Task.WhenAll(
                    Dot3.ScaleTo(1.3, 400, Easing.CubicInOut),
                    Dot3.FadeTo(0.3, 400, Easing.CubicInOut)
                );
                await Task.WhenAll(
                    Dot3.ScaleTo(1, 400, Easing.CubicInOut),
                    Dot3.FadeTo(1, 400, Easing.CubicInOut)
                );
            }
        }
}

