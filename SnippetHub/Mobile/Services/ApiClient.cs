using Shared.Responses_Handling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Mobile.Services
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(Helpers.ApiConfig.BaseUrl);
        }

        public async Task<ServiceResult<T>> GetAsync<T>(string endpoint) where T : class, new()
        {
            var response = await _httpClient.GetAsync(endpoint);

            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new Exception(content);

            return JsonSerializer.Deserialize<ServiceResult<T>>(content,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<ServiceResult<T>> PostAsync<T>(string endpoint, object data) where T : class, new()
        {
            var response = await _httpClient.PostAsJsonAsync(endpoint, data);

            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new Exception(content);

            return JsonSerializer.Deserialize<ServiceResult<T>>(content,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<ServiceResult<T>> PutAsync<T>(string endpoint, object data) where T : class, new()
        {
            var response = await _httpClient.PutAsJsonAsync(endpoint, data);

            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new Exception(content);

            return JsonSerializer.Deserialize<ServiceResult<T>>(content,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<ServiceResult<T>> DeleteAsync<T>(string endpoint) where T : class, new()
        {
            var response = await _httpClient.DeleteAsync(endpoint);

            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new Exception(content);

            return JsonSerializer.Deserialize<ServiceResult<T>>(content,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public void SetToken(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }
    }
}
