using Shared.DTOs.RequestDTOs.Shared;

namespace Shared.DTOs.ResponseDTOs.Shared
{
    public class PagerResponse : PagerRequest
    {
        public int Count { get; set; }
    }
}
