namespace API.Infrastructure.RequestDTOs.User
{
    public class UserGetFilterRequest : UserRequest
    {
        public int? UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
