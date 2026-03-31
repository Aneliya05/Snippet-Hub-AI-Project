using Data_Layer.Entities;
using Data_Layer.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Services
{
    public class UserServices : BaseServices<User>
    {
        public UserServices(AppDbContext context) : base(context)
        {
            
        }
        public User Authenticate(string username, string password)
        {
            return Items
                .FirstOrDefault(u =>
                    u.Username == username &&
                    u.Password == password
                );
        }

        public User Register(string username, string email, string password)
        {

            if (Items.Any(u => u.Username == username))
                throw new Exception("Username already exists");

            if (Items.Any(u => u.Email == email))
                throw new Exception("Email already exists");

            var authUser = new User
            {
                Username = username,
                Email = email,
                Password = password
            };

            Save(authUser);
            return authUser;
        }

        public string GetUsername(int userId)
        {
            var user = GetById(userId);
            return user.Username;
        }

        public string GetEmail(int userId)
        {
            var user = GetById(userId);
            return user.Email;
        }

        public bool EmailExists(string email, int userId)
        {
            return Items.Any(x => x.Email == email && x.Id != userId);
        }

        public bool UsernameExists(string username, int userId)
        {
            return Items.Any(x => x.Username == username && x.Id != userId);
        }
    }
}
