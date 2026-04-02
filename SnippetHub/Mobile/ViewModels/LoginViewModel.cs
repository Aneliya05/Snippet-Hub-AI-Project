using Mobile.Services;
using Mobile.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.ViewModels
{
    public class LoginViewModel
    {
        private readonly UserService _userService;
        private readonly TokenStorage _tokenStorage;
        private readonly ApiClient _apiClient;

        public string Username { get; set; }
        public string Password { get; set; }

        public Command LoginCommand { get; }

        public LoginViewModel(UserService userService, TokenStorage storage, ApiClient apiClient)
        {
            _userService = userService;
            _tokenStorage = storage;
            _apiClient = apiClient;

            LoginCommand = new Command(async () => await Login());
        }

        private async Task Login()
        {
            try
            {
                var token = await _userService.Login(Username, Password);

                await _tokenStorage.SaveTokenAsync(token);

                _apiClient.SetToken(token);

                Application.Current.MainPage = new NavigationPage(new HomePage());
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}
