using IdentityManaging.Infrastructure.Repositories.DTOs.UserManagmentRepository;
using System.Threading.Tasks;

namespace IdentityManaging.Infrastructure.Repositories.Dapper.UserManagment
{
    public interface IUserManagmentDapperRepository
    {
        Task<UserRegistrationResultDto> RegisterUserAsync(UserRegistrationDto userRegistrationDto);
    }
}