using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Services
{
    public class TokenStorage
    {
        private const string Key = "auth_token";

        public async Task SaveTokenAsync(string token)
        {
            await SecureStorage.SetAsync(Key, token);
        }

        public async Task<string> GetTokenAsync()
        {
            return await SecureStorage.GetAsync(Key);
        }

        public void Remove()
        {
            SecureStorage.Remove(Key);
        }
    }
}
