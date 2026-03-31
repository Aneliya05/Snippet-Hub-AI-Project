using API.Infrastructure.RequestDTOs.Shared;

namespace API.Infrastructure.RequestDTOs.User
{
    public class UserGetRequest : BaseGetRequest
    {
       public UserGetFilterRequest Filter { get; set; }
    }
}
