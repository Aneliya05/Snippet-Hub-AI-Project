using Mobile.Services;
using Shared.DTOs.ResponseDTOs.Snippet;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.ViewModels
{
    public class HomeViewModel
    {
        private readonly SnippetService _service;
        public ObservableCollection<SnippetResponseDto> Snippets { get; set; } = new();
        public HomeViewModel(SnippetService service)
        {
            _service = service;
        }

        public async Task LoadSnippets(string? category = null)
        {
            var data = await _service.GetSnippets();

            Snippets.Clear();

            foreach(var item in data)
            {
                Snippets.Add(item);
            }
        }
    }
}
