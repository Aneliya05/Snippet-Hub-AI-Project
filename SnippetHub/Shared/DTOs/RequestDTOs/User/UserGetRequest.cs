using Shared.DTOs.RequestDTOs.Shared;
using Shared.DTOs.RequestDTOs.User;

namespace API.Infrastructure.RequestDTOs.User
{
    public class UserGetRequest : BaseGetRequest
    {
       public UserGetFilterRequest Filter { get; set; }
    }
}
