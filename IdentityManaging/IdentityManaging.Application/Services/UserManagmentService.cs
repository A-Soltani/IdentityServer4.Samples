using IdentityManaging.Application.Services.DTOs;
using IdentityManaging.Infrastructure.Repositories.Dapper.UserManagment;
using IdentityManaging.Infrastructure.Repositories.DTOs.UserManagmentRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IdentityManaging.Application.Services
{
    public class UserManagmentService : IUserManagmentService
    {
        private readonly IUserManagmentDapperRepository _userManagmentDapperRepository;

        public UserManagmentService(IUserManagmentDapperRepository userManagmentDapperRepository)
        {
            _userManagmentDapperRepository = userManagmentDapperRepository;
        }
        public async Task RegisterUserAsync(UserRegistrationDto userRegistrationDto)
        {
            if ((isActive) &&
                (string.IsNullOrEmpty(BDate) ||
                    string.IsNullOrEmpty(FatherName) ||
                    string.IsNullOrEmpty(CodeMelli) ||
                    string.IsNullOrEmpty(HomeTel) ||
                    string.IsNullOrEmpty(MobilePhone) ||
                    string.IsNullOrEmpty(FullNameOfOwner) ||
                    string.IsNullOrEmpty(HomeAddress)))
            {
                basketResult = new BasketResult<int>();
                basketResult.IsSuccess = false;
                basketResult.Result = null;
                basketResult.persianErrorMessages.Add(Messages.Err_PersianMandetoryMessage);
                return basketResult;
            }

            int AccountCreator_Username = userId;
            string salt = Helper.GenerateRandomStringNumber(9);
            AuthorizationBusiness.Password UserEnteredPassword = new AuthorizationBusiness.Password(Password, salt.ToInt32());
            string newPass = UserEnteredPassword.ComputeSaltedHash(Enumes.TypeOfSHA.SHA512);
            await _userManagmentDapperRepository.RegisterUserAsync(userRegistrationDto);
        }
    }
}
