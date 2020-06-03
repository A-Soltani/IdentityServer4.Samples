using IdentityServer4.Models;
using IdentityServer4.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityManaging.IdentityServer.API.Configuration.UserConfig
{
    public class ResourceOwenerPasswordValidator : IResourceOwnerPasswordValidator
    {

        private readonly IUserManagment _userManagment;

        public ResourceOwenerPasswordValidator(IUserManagment userManagment)
        {
            //_userManagment = userManagment;
            _userManagment = new UserManagment();
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var userName = context.UserName;
            var password = context.Password;

            var user = await _userManagment.FindUser(userName);

            if (user != null && await _userManagment.CheckPassword(user, password))
                context.Result = new GrantValidationResult(
                    subject: userName,
                    authenticationMethod: "custom",
                    claims: new[] { new Claim("name", "whatever") });
            else
                context.Result = new GrantValidationResult(
                    TokenRequestErrors.InvalidGrant,
                    "invalid custom credential");
        }
    }
}
