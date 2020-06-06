using IdentityManaging.Application.Services;
using IdentityManaging.Infrastructure.Repositories.ConnectionFactories;
using IdentityManaging.Infrastructure.Repositories.Dapper.UserManagment;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityManaging.IdentityServer.CustomExtensions
{
    public static class CustomServiceCollectionExtensions
    {
        //public static IServiceCollection AddCustomMvc(this IServiceCollection services)
        //{
        //    // Add framework services.
        //    services.AddMvc(options =>
        //    {
        //        options.Filters.Add(typeof(HttpGlobalExceptionFilter));
        //    })
        //        .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
        //        .AddFluentValidation()
        //        //.AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver())
        //        .AddControllersAsServices();

        //    return services;
        //}

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IdbConnectionFactory, DbConnectionFactory>();
            services.AddSingleton<IUserManagmentDapperRepository, UserManagmentDapperRepository>();

            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<IUserManagmentService, UserManagmentService>();

            return services;
        }
    }
}
