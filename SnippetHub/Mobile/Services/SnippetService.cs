using Shared.DTOs.RequestDTOs.Snippet;
using Shared.DTOs.RequestDTOs.User;
using Shared.DTOs.ResponseDTOs.Snippet;
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
        private readonly ApiClient _apiClient;
        public SnippetService(ApiClient api)
        {
            _apiClient = api;
        }

        public async Task<List<SnippetResponseDto>> GetSnippets(string? category = null)
        {
            string endpoint = "api/snippets/getAll";

            if(!string.IsNullOrEmpty(category))
            {
                endpoint += $"?category={category}"; // Uri.EscapeDataString(category) - good to be used; 
            }

            var result = await _apiClient.GetAsync<List<SnippetResponseDto>>(endpoint);

            return result?.Data ?? new List<SnippetResponseDto>();
        }
    }
}
