namespace Shared.DTOs.RequestDTOs.Article
{
    public class ArticleRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public DateOnly DatePublished { get; set; }
    }
}
