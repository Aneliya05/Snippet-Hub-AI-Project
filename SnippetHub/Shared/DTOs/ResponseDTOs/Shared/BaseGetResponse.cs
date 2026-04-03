namespace Shared.DTOs.ResponseDTOs.Shared
{
    public class BaseGetResponse<EDto>
    {
        public List<EDto> Items { get; set; }
        public PagerResponse Pager { get; set; }
        public string OrderBy { get; set; }
        public bool SortAscending { get; set; }
    }
}
