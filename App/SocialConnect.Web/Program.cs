using Microsoft.EntityFrameworkCore;
using SocialConnect.Core.Context;

namespace SocialConnect.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //Connection string
            builder.Services.AddDbContext<SocialDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("SocialConnect")));

            //Benchmarks
            //BenchmarkRunner.Run<AuthController>();
            //BenchmarkRunner.Run<UsersController>();

            //Adding the DependencyInjection.cs class to the Services Container.
            builder.Services.AddWebServices();

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

            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Auth}/{action=Login}/{id?}");

            app.MapControllerRoute(
                name: "Auth",
                pattern: "{controller=Auth}/{action=Login}/{id?}");
            

            //app.MapIdentityApi<User>();

            app.Run();
        }
    }
}
