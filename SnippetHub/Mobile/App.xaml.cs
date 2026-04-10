using Mobile.Services;
using Mobile.Views;

namespace Mobile
{
    public partial class App : Application
    {
        public App(ApiClient apiClient, TokenStorage tokenStorage, LoginPage loginPage, HomePage homePage)
        {
            InitializeComponent();

            InitializeApp(apiClient, tokenStorage, loginPage, homePage);
        }

        private async void InitializeApp(ApiClient apiClient, TokenStorage tokenStorage, LoginPage loginPage, HomePage homePage)
        {
            var token = await tokenStorage.GetTokenAsync();
                
            if (!string.IsNullOrEmpty(token))
            {
                apiClient.SetToken(token);

                MainPage = new NavigationPage(homePage);
            }
            else
            {
                MainPage = new NavigationPage(loginPage);
            }
        }
    }
}
