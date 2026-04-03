using Shared.DTOs.RequestDTOs.Snippet;
using Shared.DTOs.RequestDTOs.User;
using Shared.DTOs.ResponseDTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Services
{
    public class SnippetService
    {
        public async Task<List<SnippetGetRequest>> Login(string username, string password)
        {
            var result = await _apiClient.PostAsync<SnippetRequest>(
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
    }
}
