namespace Shared.DTOs.RequestDTOs.User
{
    public class UserGetFilterRequest 
    {
        public int? UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
