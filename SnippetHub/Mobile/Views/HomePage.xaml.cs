using Microsoft.Maui.Controls;
using Mobile.ViewModels;

namespace Mobile.Views
{
    public partial class HomePage : ContentPage
    {
        private Border? _activeChip;

        public HomePage(HomeViewModel viewModel)
        {
            InitializeComponent();
            _activeChip = ChipAll;

            BindingContext = viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (BindingContext is HomeViewModel vm)
            {
                await vm.LoadSnippets();
            }
        }

        // ── Tab switching ────────────────────────────────────────

        private void OnSnippetsTabTapped(object sender, EventArgs e)
        {
            SnippetsTab.IsVisible = true;
            ArticlesTab.IsVisible = false;

            SnippetsTabBorder.BackgroundColor = Color.FromArgb("#1E2A28");
            SnippetsTabBorder.Stroke = Color.FromArgb("#4FCCB0");
            SnippetsTabBorder.StrokeThickness = 1;
            SnippetsTabLabel.TextColor = Color.FromArgb("#4FCCB0");
            SnippetsTabLabel.FontAttributes = FontAttributes.Bold;

            ArticlesTabBorder.BackgroundColor = Colors.Transparent;
            ArticlesTabBorder.StrokeThickness = 0;
            ArticlesTabLabel.TextColor = Color.FromArgb("#6B7280");
            ArticlesTabLabel.FontAttributes = FontAttributes.None;
        }

        private void OnArticlesTabTapped(object sender, EventArgs e)
        {
            SnippetsTab.IsVisible = false;
            ArticlesTab.IsVisible = true;

            ArticlesTabBorder.BackgroundColor = Color.FromArgb("#1E2A28");
            ArticlesTabBorder.Stroke = Color.FromArgb("#4FCCB0");
            ArticlesTabBorder.StrokeThickness = 1;
            ArticlesTabLabel.TextColor = Color.FromArgb("#4FCCB0");
            ArticlesTabLabel.FontAttributes = FontAttributes.Bold;

            SnippetsTabBorder.BackgroundColor = Colors.Transparent;
            SnippetsTabBorder.StrokeThickness = 0;
            SnippetsTabLabel.TextColor = Color.FromArgb("#6B7280");
            SnippetsTabLabel.FontAttributes = FontAttributes.None;
        }

        // ── Filter chips ─────────────────────────────────────────

        private void OnChipAllTapped(object sender, EventArgs e) =>
            ActivateChip(ChipAll);

        private void OnChipTapped(object sender, EventArgs e)
        {
            if (sender is TapGestureRecognizer tap &&
                tap.Parent is Label label &&
                label.Parent is Border chip)
            {
                ActivateChip(chip);
            }
        }

        private async void ActivateChip(Border selected)
        {
            // Deactivate previous
            if (_activeChip != null)
            {
                _activeChip.BackgroundColor = Colors.Transparent;
                _activeChip.Stroke = Color.FromArgb("#2A2E3D");
                if (_activeChip.Content is Label lbl)
                {
                    lbl.TextColor = Color.FromArgb("#6B7280");
                    lbl.FontAttributes = FontAttributes.None;
                }
            }

            // Activate selected
            selected.BackgroundColor = Color.FromArgb("#1E2A28");
            selected.Stroke = Color.FromArgb("#4FCCB0");
            if (selected.Content is Label activeLbl)
            {
                activeLbl.TextColor = Color.FromArgb("#4FCCB0");
                activeLbl.FontAttributes = FontAttributes.Bold;
            }

            _activeChip = selected;

            if (BindingContext is HomeViewModel vm)
            {
                string? category = null;

                if (selected.Content is Label lbl)
                {
                    category = lbl.Text == "All" ? null : lbl.Text;
                }

                await vm.LoadSnippets(category);
            }
        }
    }
}
