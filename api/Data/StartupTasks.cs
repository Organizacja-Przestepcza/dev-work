using System.Security.Claims;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace api.Data;

public static class StartupTasks
{
    public static async Task AdminSeedAsync(IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

        var adminUser = await userManager.FindByEmailAsync("admin@admin.com");
        if (adminUser == null)
        {
            adminUser = new AppUser
            {
                UserName = "Admin",
                Email = "admin@admin.com",
                DisplayName = "Admin",
                LockoutEnabled = false,
                NormalizedEmail = "ADMIN@ADMIN.COM",
                NormalizedUserName = "ADMIN"
            };

            var adminPassword = Environment.GetEnvironmentVariable("ADMIN_PASSWORD") ?? "Admin123!";
            var result =
                await userManager.CreateAsync(adminUser, adminPassword!);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, "Administrator");
                await userManager.AddClaimAsync(adminUser, new Claim(ClaimTypes.Role, "Administrator"));
            }
        }
    }

    public static async Task DatabaseUpdateAsync(IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        // Apply any pending migrations and create the database if it doesn't exist
        await dbContext.Database.MigrateAsync();
    }
}