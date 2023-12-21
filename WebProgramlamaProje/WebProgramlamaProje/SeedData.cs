using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using WebProgramlamaProje.Models.Domain;

public static class SeedData
{
    public static async Task Initialize(IServiceProvider serviceProvider)
    {
        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        string[] roleNames = { "Admin", "User" };


        IdentityResult roleResult;

        foreach (var roleName in roleNames)
        {
            var roleExist = await roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        var adminUser = new ApplicationUser
            {
                Name = "admin",
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = "admin",
                Email = "admin@gmail.com",
                EmailConfirmed = true,
             };

        string adminPassword = "Admin@123";

        var user = await userManager.FindByEmailAsync(adminUser.Email);

        if (user == null)
        {
            var createAdminUser = await userManager.CreateAsync(adminUser, adminPassword);
            if (createAdminUser.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }

        var regularUser = new ApplicationUser
			{
		    	Name = "customer",
		    	SecurityStamp = Guid.NewGuid().ToString(),
		    	UserName = "customer",
		    	Email = "customer@gmail.com",
				EmailConfirmed = true,
			};

        string regularPassword = "User@123";

        var regularUserCheck = await userManager.FindByEmailAsync(regularUser.Email);

        if (regularUserCheck == null)
        {
            var createRegularUser = await userManager.CreateAsync(regularUser, regularPassword);
            if (createRegularUser.Succeeded)
            {
                await userManager.AddToRoleAsync(regularUser, "User");
            }
        }
    }
}
