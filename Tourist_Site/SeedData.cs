using Tourist_Site.Models;
using Microsoft.AspNetCore.Identity;

namespace Tourist_Site
{
    public class SeedData
    {
        public static async Task Seed(
          RoleManager<IdentityRole> roleManager
        )
        {
            await SeedRoles(roleManager);
        }

 
        public static async Task SeedRoles(
            RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                var role = new IdentityRole
                {
                    Name = "Admin",
                };
                var result = await roleManager.CreateAsync(role);
            }
            if (!roleManager.RoleExistsAsync("User").Result)
            {
                var role = new IdentityRole
                {
                    Name = "User",
                };
                var result = await roleManager.CreateAsync(role);
            }

        }
    }
}
