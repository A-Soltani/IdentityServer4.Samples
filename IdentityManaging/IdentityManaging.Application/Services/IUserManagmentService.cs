using IdentityManaging.Infrastructure.Repositories.DTOs.UserManagmentRepository;
using System.Threading.Tasks;

namespace IdentityManaging.Application.Services
{
    public interface IUserManagmentService
    {
        Task RegisterUserAsync(UserRegistrationDto userRegistrationDto);
    }
}