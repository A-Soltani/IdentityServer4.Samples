using IdentityManaging.IdentityServer.API.Configuration.UserConfig;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityManaging.IdentityServer.API.CustomExtensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureClasses(this IServiceCollection services)
        {
            services.AddTransient<IUserManagment, UserManagment>();

            return services;
        }

        public static IServiceCollection AddCustomUserStore(this IServiceCollection services)
        {
            services.AddIdentityServer()
                .AddResourceOwnerValidator<ResourceOwenerPasswordValidator>()
                .AddProfileService<CustomProfileService>();

            return services;
        }
    }
}
