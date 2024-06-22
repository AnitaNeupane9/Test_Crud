using LMS.Models;
using Microsoft.AspNetCore.Identity;

namespace LMS.Data
{
    public class SeedingData
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var _roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var _userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            string[] Roles = { "ADMIN", "STUDENT" };

            foreach (string roleName in Roles)
            {
                if (!await _roleManager.RoleExistsAsync(roleName))
                {
                    await _roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            var adminUser = await _userManager.FindByEmailAsync("admin@example.com");

            if (adminUser == null)
            {
                adminUser = new ApplicationUser
                {
                    UserName = "admin@example.com",
                    Email = "admin@example.com",
                    EmailConfirmed = true
                };

                await _userManager.CreateAsync(adminUser, "Admin123!");
                await _userManager.AddToRoleAsync(adminUser, "ADMIN");
            }
        }
    }
}
