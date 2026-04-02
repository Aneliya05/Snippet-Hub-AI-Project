using Shared.DTOs.RequestDTOs.Snippet;
using Shared.DTOs.ResponseDTOs.Shared;
using Shared.DTOs.Snippet;

namespace Shared.DTOs.ResponseDTOs.Snippet
{
    public class SnippetGetResponse : BaseGetResponse<SnippetGetRequest>
    {
        public SnippetGetFilterRequest Filter { get; set; }
    }
}
