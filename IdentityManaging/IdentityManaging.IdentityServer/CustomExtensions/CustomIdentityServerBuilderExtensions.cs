
using IdentityManaging.IdentityServer.Data;
using IdentityManaging.IdentityServer.Infrastructure.IdentityServer4Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityManaging.IdentityServer.API.CustomExtensions
{
    public static class CustomIdentityServerBuilderExtensions
    {
        //public static IIdentityServerBuilder AddCustomUserStore(this IIdentityServerBuilder builder)
        //{
        //    builder.Services.AddSingleton<IUserRepository, UserRepository>();
        //    //builder.AddProfileService<CustomProfileService>();
        //    //builder.AddResourceOwnerValidator<CustomResourceOwnerPasswordValidator>();

        //    return builder;
        //}

        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            // Identity server DB
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDbContext>(config =>
            {
                config.UseSqlServer(connectionString);
                //config.UseInMemoryDatabase("Memory");
            });

            return services;
        }

        public static IServiceCollection AddCustomAspIdentity(this IServiceCollection services)
        {
            // AddIdentity registers the services
            services.AddIdentity<IdentityUser, IdentityRole>(config =>
            {
                config.Password.RequiredLength = 4;
                config.Password.RequireDigit = false;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireUppercase = false;
            })
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            return services;
        }

        public static IServiceCollection AddCustomIdentityServer(this IServiceCollection services)
        {
            services.AddIdentityServer()
               .AddAspNetIdentity<IdentityUser>()
               .AddInMemoryApiResources(Config.GetApis())
               .AddInMemoryIdentityResources(Config.GetIdentityResources())
               .AddInMemoryClients(Config.GetClients())
               .AddDeveloperSigningCredential();

            return services;
        }


    }
}
