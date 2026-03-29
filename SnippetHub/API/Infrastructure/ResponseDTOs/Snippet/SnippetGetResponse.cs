using API.Infrastructure.RequestDTOs.Snippet;
using API.Infrastructure.ResponseDTOs.Shared;

namespace API.Infrastructure.ResponseDTOs.Snippet
{
    public class SnippetGetResponse : BaseGetResponse<Data_Layer.Entities.Snippet>
    {
        public SnippetGetFilterRequest Filter { get; set; }
    }
}
