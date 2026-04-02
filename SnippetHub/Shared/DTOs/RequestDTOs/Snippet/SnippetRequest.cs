namespace Shared.DTOs.RequestDTOs.Snippet
{
    public class SnippetRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public DateOnly DatePublished { get; set; }
    }
}
