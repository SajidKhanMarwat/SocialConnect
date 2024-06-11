using Microsoft.AspNetCore.Identity;
using SocialConnect.Application.IServices;
using SocialConnect.Application.NewFolder.Services;
using SocialConnect.Application.Services.IServices;
using SocialConnect.Application.Services.Services;
using SocialConnect.Core.Context;
using SocialConnect.Core.Entities;
using SocialConnect.Core.IRepos;
using SocialConnect.Infrastructure.Repos;
using SocialConnect.Web.AutoMapper;

//namespace SocialConnect.Web
namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            // Register repositories
            //builder.Services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));//Register GenericRepo for all Entities
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            
            //AutoMapper
            services.AddAutoMapper(typeof(Mapping));
            
            //Logs
            services.AddScoped<ILogsService, LogsService>();
            services.AddScoped<ILogsRepository, LogsRepository>();

            //Identity
            //This will implement Cookies Authentication By Default.

            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
                options.SignIn.RequireConfirmedAccount = false;
            })
            .AddEntityFrameworkStores<SocialDbContext>()
            .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Auth/Login";
                //options.AccessDeniedPath = "/Auth/AccessDenied";
            });



            return services;
        }
    }
}
