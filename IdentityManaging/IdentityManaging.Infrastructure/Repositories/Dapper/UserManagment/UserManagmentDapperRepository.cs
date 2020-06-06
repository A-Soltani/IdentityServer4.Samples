using Dapper;
using IdentityManaging.Infrastructure.Repositories.ConnectionFactories;
using IdentityManaging.Infrastructure.Repositories.DTOs.UserManagmentRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace IdentityManaging.Infrastructure.Repositories.Dapper.UserManagment
{
    public class UserManagmentDapperRepository : DapperRepositoryContext, IUserManagmentDapperRepository
    {
        public UserManagmentDapperRepository(IdbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
        {
        }

        public async Task<UserRegistrationResultDto> RegisterUserAsync(UserRegistrationDto userRegistrationDto)
        {
            using (var connectionString = _dbConnectionFactory.GetDefaultServerConnectionString())
            {
                var parameters = new DynamicParameters();

                parameters.Add("@Password", SqlDbType.VarChar);

                parameters.Add("@UssdPass", SqlDbType.VarChar);

                parameters.Add("@Salt", SqlDbType.VarChar);

                parameters.Add("@AccountCreator_Username", SqlDbType.Int);

                parameters.Add("@isActive", SqlDbType.Bit);

                parameters.Add("@MobilePhone", SqlDbType.NVarChar);

                parameters.Add("@FullNameOfOwner", SqlDbType.NVarChar);

                parameters.Add("@HomeAddress", SqlDbType.VarChar);

                parameters.Add("@HomeTel", SqlDbType.VarChar);

                parameters.Add("@MailAddress", SqlDbType.NVarChar);

                parameters.Add("@CodeMelli", SqlDbType.NVarChar);

                parameters.Add("@BDate", SqlDbType.VarChar);

                parameters.Add("@FatherName", SqlDbType.NVarChar);

                parameters.Add("@Description", SqlDbType.NVarChar);

                parameters.Add("@UserType", SqlDbType.TinyInt);

                parameters.Add("@ExpirationDate", SqlDbType.DateTime);

                // Outputs
                parameters.Add("@OUT_USERNAME", SqlDbType.Int, direction: ParameterDirection.Output, size: 1000);
                parameters.Add("@OUT_ErrorMessage", SqlDbType.NVarChar, direction: ParameterDirection.Output, size: 1000);

                await connectionString.QueryAsync("MMCAddUser", parameters, commandType: CommandType.StoredProcedure);

                var outErrorMessageParam = parameters.Get<string>("@OUT_ErrorMessage");
                var outUsernameParam = parameters.Get<int>("@OUT_USERNAME");

                UserRegistrationResultDto userRegistrationResultDto = new UserRegistrationResultDto()
                {
                    ErrorMessage = outErrorMessageParam,
                    Username = outUsernameParam
                };

                return userRegistrationResultDto;
            }
        }

    }
}
