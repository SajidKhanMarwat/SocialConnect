using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SocialConnect.Core.Context;
using SocialConnect.Core.Entities;

namespace SocialConnect.Web.SeedData
{
    public class IdentityRolesData
    {
        //Adding below Roles to the Database
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SocialDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<SocialDbContext>>()))
            {
                var roleManager = serviceProvider.GetRequiredService<RoleManager<UserRole>>();

                string[] roleNames = { "Admin", "Reader", "Editor", "SocialUser" };

                foreach (var roleName in roleNames)
                {
                    if (!await roleManager.RoleExistsAsync(roleName))
                    {
                        var role = new UserRole { Name = roleName };
                        await roleManager.CreateAsync(role);
                    }
                }
            }
        }
    }
}
