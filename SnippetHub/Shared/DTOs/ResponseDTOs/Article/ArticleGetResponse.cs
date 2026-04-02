using Shared.DTOs.RequestDTOs.Article;
using Shared.DTOs.ResponseDTOs.Shared;

namespace Shared.DTOs.ResponseDTOs.Article
{
    public class ArticleGetResponse : BaseGetResponse<ArticleGetRequest>
    {
        public ArticleGetFilterRequest Filter { get; set; }
    }
}
