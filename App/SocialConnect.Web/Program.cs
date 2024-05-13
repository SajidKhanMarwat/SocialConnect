using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SocialConnect.Application.AutoMapper;
using SocialConnect.Application.NewFolder.IServices;
using SocialConnect.Application.NewFolder.Services;
using SocialConnect.Application.Services.IServices;
using SocialConnect.Application.Services.Services;
using SocialConnect.Core.Context;
using SocialConnect.Core.Entities;
using SocialConnect.Core.IRepos;
using SocialConnect.Infrastructure.Repos;
using SocialConnect.Web.AutoMapper;

namespace SocialConnect.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<SocialDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("SocialConnect")));

            // Register repositories
            //builder.Services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));//Register GenericRepo for all Entities
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();
            //AutoMapper
            builder.Services.AddAutoMapper(typeof(Mapping));
            //Logs
            builder.Services.AddScoped<ILogsService,LogsService>();
            builder.Services.AddScoped<ILogsRepository,LogsRepository>();

            //Identity
            //This will implement Cookies Authentication By Default.
            builder.Services.AddIdentity<User, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
                options.SignIn.RequireConfirmedAccount = false;
            })
            .AddEntityFrameworkStores<SocialDbContext>()
            .AddDefaultTokenProviders();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            //app.MapIdentityApi<User>();

            app.Run();
        }
    }
}
