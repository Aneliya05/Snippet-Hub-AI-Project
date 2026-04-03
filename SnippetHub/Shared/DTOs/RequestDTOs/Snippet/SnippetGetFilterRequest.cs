using Shared.DTOs.RequestDTOs.Snippet;

namespace Shared.DTOs.Snippet
{
    public class SnippetGetFilterRequest : SnippetRequest
    {
        public string? Category { get; set; }
        public string? Search { get; set; }
    }
}
