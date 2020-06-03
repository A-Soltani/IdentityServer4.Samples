using IdentityModel;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityManaging.IdentityServer.API.Configuration.UserConfig
{
    public class CustomProfileService : IProfileService
    {
        private readonly IUserManagment _userManagment;

        public CustomProfileService(IUserManagment userManagment)
        {
            //_userManagment = userManagment;
            _userManagment = new UserManagment();
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var sub = context.Subject.FindFirst("sub").Value;
            if (sub != null)
            {
                var user = await _userManagment.FindUser(sub);
                ClaimsPrincipal cp = await getClaims(user);

                var claims = cp.Claims;
                //if (context.AllClaimsRequested == false ||
                if (context.RequestedClaimTypes != null && context.RequestedClaimTypes.Any())
                    claims = claims.Where(c => context.RequestedClaimTypes.Contains(c.Type)).ToArray().AsEnumerable();

                context.IssuedClaims = claims.ToList();
            }
        }

        private async Task<ClaimsPrincipal> getClaims(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            var id = new ClaimsIdentity();
            id.AddClaim(new Claim(JwtClaimTypes.PreferredUserName, user.UserName));

            id.AddClaims(await _userManagment.GetClaims(user));

            return new ClaimsPrincipal(id);
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var sub = context.Subject.GetSubjectId();
            var user = await _userManagment.FindUser(context.Subject.GetSubjectId());
            context.IsActive = user != null;
        }

    }
}
