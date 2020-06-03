using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityManaging.IdentityServer.API.Configuration.UserConfig
{
    public class UserManagment : IUserManagment
    {
        public Task<User> FindUser(string userName)
        {
            User user = GetUsers().FirstOrDefault(u => u.UserName == userName);

            return Task.FromResult(user);
        }
        public IEnumerable<User> GetUsers()
        {
            List<User> users = new List<User>()
            {
                new User(){
                    UserId="1010",
                    Password = "123",
                    UserName = "Ali"
                },
                new User(){
                    UserId="2020",
                    Password = "321",
                    UserName = "Majid"
                }
            };

            return users;
        }

        public Task<bool> CheckPassword(User user, string password) => Task.FromResult(user.Password == password);

        public Task<List<Claim>> GetClaims(User user)
        {
            List<Claim> claims = new List<Claim>() {
                new Claim("UserId", user.UserId),
                new Claim("UserName", user.UserName)
            };

            return Task.FromResult(claims);
        }

    }
}
