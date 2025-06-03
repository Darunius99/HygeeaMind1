using HygeeaMind.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore; 

namespace HygeeaMind.Utilities
{
    public static class DbInitializer
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            await context.Database.MigrateAsync(); 
            string adminRoleName = "Admin";
            string userRoleName = "User";

            if (await roleManager.FindByNameAsync(adminRoleName) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(adminRoleName));
            }

            if (await roleManager.FindByNameAsync(userRoleName) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(userRoleName));
            }

            
            string adminEmail = "admin@hygeeamind.com"; 
            string adminPassword = "Password123!"; 

            if (await userManager.FindByEmailAsync(adminEmail) == null)
            {
                var adminUser = new IdentityUser { UserName = adminEmail, Email = adminEmail, EmailConfirmed = true };
                var result = await userManager.CreateAsync(adminUser, adminPassword);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, adminRoleName);
                }
                else
                {
                    // Afișează erorile dacă crearea utilizatorului nu merge
                    foreach (var error in result.Errors)
                    {
                        Console.WriteLine($"Eroare creare admin: {error.Description}");
                    }
                }
            }
        }
    }
}