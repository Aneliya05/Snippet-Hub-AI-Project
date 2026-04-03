using Shared.DTOs.RequestDTOs.Shared;

namespace Shared.DTOs.RequestDTOs.Article
{
    public class ArticleGetRequest : BaseGetRequest
    {
        public ArticleGetFilterRequest Filter { get; set; }
    }
}
