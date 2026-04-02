using Mobile.Services;
using Mobile.Views;

namespace Mobile
{
    public partial class App : Application
    {
        public App(ApiClient apiClient, TokenStorage tokenStorage)
        {
            InitializeComponent();

            MainPage = new ContentPage();

            InitializeApp(apiClient, tokenStorage);
        }

        private async void InitializeApp(ApiClient apiClient, TokenStorage tokenStorage)
        {
            var token = await tokenStorage.GetTokenAsync();

            if (!string.IsNullOrEmpty(token))
            {
                apiClient.SetToken(token);

                MainPage = new NavigationPage(new HomePage());
            }
            else
            {
                MainPage = new NavigationPage(new LoginPage());
            }
        }
    }
}
