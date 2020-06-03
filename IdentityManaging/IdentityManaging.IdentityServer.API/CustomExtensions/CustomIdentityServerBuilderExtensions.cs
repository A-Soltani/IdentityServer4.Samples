using IdentityManaging.IdentityServer.Domain.AggregatesModel.User;
using IdentityManaging.IdentityServer.Infrastructure.Repositories.UserRepository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityManaging.IdentityServer.API.CustomExtensions
{
    public static class CustomIdentityServerBuilderExtensions
    {
        public static IIdentityServerBuilder AddCustomUserStore(this IIdentityServerBuilder builder)
        {
            builder.Services.AddSingleton<IUserRepository, UserRepository>();
            //builder.AddProfileService<CustomProfileService>();
            //builder.AddResourceOwnerValidator<CustomResourceOwnerPasswordValidator>();

            return builder;
        }
    }
}
