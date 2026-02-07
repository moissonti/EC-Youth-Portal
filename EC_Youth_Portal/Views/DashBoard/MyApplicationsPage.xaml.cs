using Microsoft.Maui.Controls;
using EC_Youth_Portal.ViewModel;

namespace EC_Youth_Portal.Views.DashBoard
{
    public partial class MyApplicationsPage : ContentPage
    {
        private MyApplicationsPageViewModel _viewModel;

        public MyApplicationsPage(MyApplicationsPageViewModel viewmodel)
        {
            InitializeComponent();
            _viewModel = viewmodel;
            BindingContext = viewmodel;

            // Subscribe to property changes for smooth animations
            _viewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Force close drawer and reset ViewModel state when returning to page
            if (_viewModel != null)
            {
                // Reset ViewModel state first (this prevents binding issues)
                _viewModel.IsDrawerOpen = false;

                // Then reset UI state
                ResetDrawerStateImmediate();
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            // Force close drawer when leaving the page
            if (_viewModel != null)
            {
                _viewModel.IsDrawerOpen = false;
            }

            // Reset drawer visual state immediately
            ResetDrawerStateImmediate();
        }

        private void ResetDrawerStateImmediate()
        {
            var drawer = FindDrawerFrame();
            var overlay = FindOverlay();

            if (drawer != null)
            {
                // Cancel any running animations
                drawer.CancelAnimations();

                // Reset to closed state immediately (no animation)
                drawer.TranslationX = 400;
                drawer.IsVisible = false;
            }

            if (overlay != null)
            {
                overlay.IsVisible = false;
            }
        }

        private async void OnViewModelPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MyApplicationsPageViewModel.IsDrawerOpen))
            {
                if (_viewModel.IsDrawerOpen)
                {
                    await AnimateDrawerOpen();
                }
                else
                {
                    await AnimateDrawerClose();
                }
            }
        }

        private async Task AnimateDrawerOpen()
        {
            var drawer = FindDrawerFrame();
            if (drawer == null) return;

            // Cancel any existing animations
            drawer.CancelAnimations();

            // Make drawer visible and positioned off-screen
            drawer.IsVisible = true;
            drawer.TranslationX = 400;

            // Animate sliding in from right
            await drawer.TranslateTo(0, 0, 300, Easing.CubicOut);
        }

        private async Task AnimateDrawerClose()
        {
            var drawer = FindDrawerFrame();
            if (drawer == null) return;

            // Cancel any existing animations
            drawer.CancelAnimations();

            // Animate sliding out to right
            await drawer.TranslateTo(400, 0, 250, Easing.CubicIn);

            // Hide drawer after animation
            drawer.IsVisible = false;
        }

        private Frame FindDrawerFrame()
        {
            // Find the drawer frame in the visual tree
            if (Content is Grid mainGrid)
            {
                foreach (var child in mainGrid.Children)
                {
                    if (child is Frame frame && frame.HorizontalOptions.Alignment == LayoutAlignment.End)
                    {
                        return frame;
                    }
                }
            }
            return null;
        }

        private BoxView FindOverlay()
        {
            // Find the overlay BoxView in the visual tree
            if (Content is Grid mainGrid)
            {
                foreach (var child in mainGrid.Children)
                {
                    if (child is BoxView boxView && boxView.BackgroundColor == Color.FromArgb("#000000"))
                    {
                        return boxView;
                    }
                }
            }
            return null;
        }
    }
}