using Mobile.Services;
using Mobile.ViewModels;

namespace Mobile.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }

    //private void OnTestClicked(object sender, EventArgs e)
    //{
    //    DisplayAlert("Test", "Clicked!", "OK");
    //}
}