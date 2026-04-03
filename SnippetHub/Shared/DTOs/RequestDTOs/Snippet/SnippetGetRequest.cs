using Shared.DTOs.RequestDTOs.Shared;
using Shared.DTOs.Snippet;

namespace Shared.DTOs.RequestDTOs.Snippet
{
    public class SnippetGetRequest : BaseGetRequest
    {

        public SnippetGetFilterRequest FilterRequest { get; set; }
    }
}
