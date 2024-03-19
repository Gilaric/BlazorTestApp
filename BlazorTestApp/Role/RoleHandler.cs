using BlazorTestApp.Data;
using Microsoft.AspNetCore.Identity;

namespace BlazorTestApp.Role
{
    public class RoleHandler
    {
        public static async Task CreateUserRoles(string user, string role, IServiceProvider _serviceProvider)
        {
            var roleManager = _serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = _serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            Data.ApplicationUser? identityUser;

            var userRoleCheck = await roleManager.RoleExistsAsync(role);

            if (!userRoleCheck)
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }

            if (user == null)
            {
                return;
            }
            else
            {
                identityUser = await userManager.FindByEmailAsync(user);
            }

            // Add found user to role
            await userManager.AddToRoleAsync(identityUser, role);
        }
    }
}
