using API.Infrastructure.RequestDTOs.Article;
using API.Infrastructure.ResponseDTOs.Shared;
using Data_Layer.Entities;

namespace API.Infrastructure.ResponseDTOs.Article
{
    public class ArticleGetResponse : BaseGetResponse<Data_Layer.Entities.Article>
    {
        public ArticleGetFilterRequest Filter { get; set; }
    }
}
