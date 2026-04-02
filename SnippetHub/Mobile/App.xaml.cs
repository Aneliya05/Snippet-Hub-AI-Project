using Mobile.Services;
using Mobile.Views;

namespace Mobile
{
    public partial class App : Application
    {
        public App(ApiClient apiClient, TokenStorage tokenStorage, LoginPage loginPage)
        {
            InitializeComponent();

            MainPage = new ContentPage();

            InitializeApp(apiClient, tokenStorage, loginPage);
        }

        private async void InitializeApp(ApiClient apiClient, TokenStorage tokenStorage, LoginPage loginPage)
        {
            var token = await tokenStorage.GetTokenAsync();
                
            if (!string.IsNullOrEmpty(token))
            {
                apiClient.SetToken(token);

                MainPage = new NavigationPage(new HomePage());
            }
            else
            {
                MainPage = new NavigationPage(loginPage);
            }
        }
    }
}
