using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityManaging.IdentityServer.API.Configuration.UserConfig
{
    public interface IUserManagment
    {
        Task<bool> CheckPassword(User user, string password);
        Task<User> FindUser(string userName);
        Task<List<Claim>> GetClaims(User user);
        IEnumerable<User> GetUsers();
    }
}