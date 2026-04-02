using Shared.DTOs.RequestDTOs.User;
using Shared.DTOs.ResponseDTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Services
{
    public class UserService
    {
        private readonly ApiClient _apiClient;
        public UserService(ApiClient api)
        {
            _apiClient = api;
        }

        public async Task<string> Login(string username, string password)
        {
            var result = await _apiClient.PostAsync<TokenResponse>(
                "users/createToken",
                new UserLoginRequest
                {
                    Username = username,
                    Password = password
                });

            if (!result.IsSuccess)
                throw new Exception("Login failed");

            return result.Data.Token;
        }

        public async Task<string> Register(string username, string email, string password)
        {
            var result = await _apiClient.PostAsync<TokenResponse>(
                "users/register",
                new UserRegistrationRequest
                {
                    Username = username,
                    Email = email,
                    Password = password
                });

            if (!result.IsSuccess)
                throw new Exception("Registration failed");

            return result.Data.Token;
        }
    }
}
