using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace TheCoffeeBean.Data
{
    public static class IdentitySeedData
    {
        private const string AdminRole = "Admin";
        private const string UserRole = "User"; // instead of "Member"

        private const string AdminEmail = "Admin@test.com";
        private const string UserEmail = "User@test.com";

        private const string AdminPassword = "Password123!";
        private const string UserPassword = "Password123!";

        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var services = scope.ServiceProvider;

                
                var context = services.GetRequiredService<ApplicationDbContext>();
                await context.Database.MigrateAsync();

                
                var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

                
                if (!await roleManager.RoleExistsAsync(AdminRole))
                {
                    await roleManager.CreateAsync(new IdentityRole(AdminRole));
                }

                if (!await roleManager.RoleExistsAsync(UserRole))
                {
                    await roleManager.CreateAsync(new IdentityRole(UserRole));
                }

                // Seed Admin user
                IdentityUser adminUser = await userManager.FindByNameAsync(AdminEmail);
                if (adminUser == null)
                {
                    adminUser = new IdentityUser
                    {
                        UserName = AdminEmail,
                        Email = AdminEmail,
                        EmailConfirmed = true
                    };

                    var createAdminResult = await userManager.CreateAsync(adminUser, AdminPassword);
                    if (createAdminResult.Succeeded)
                    {
                        await userManager.AddToRoleAsync(adminUser, AdminRole);
                    }
                }
                else
                {
                    
                    if (!await userManager.IsInRoleAsync(adminUser, AdminRole))
                    {
                        await userManager.AddToRoleAsync(adminUser, AdminRole);
                    }
                }

                // Seed USer Role 
                IdentityUser normalUser = await userManager.FindByNameAsync(UserEmail);
                if (normalUser == null)
                {
                    normalUser = new IdentityUser
                    {
                        UserName = UserEmail,
                        Email = UserEmail,
                        EmailConfirmed = true
                    };

                    var createUserResult = await userManager.CreateAsync(normalUser, UserPassword);
                    if (createUserResult.Succeeded)
                    {
                        await userManager.AddToRoleAsync(normalUser, UserRole);
                    }
                }
                else
                {
                    
                    if (!await userManager.IsInRoleAsync(normalUser, UserRole))
                    {
                        await userManager.AddToRoleAsync(normalUser, UserRole);
                    }
                }
            } 
        }
    }
}
