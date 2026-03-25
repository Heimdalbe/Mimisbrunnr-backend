using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Mimmisbrunnr.Persistence;
/// <summary>
/// Seeds the database
/// </summary>
/// <param name="dbContext"></param>
/// <param name="roleManager"></param>
/// <param name="userManager"></param>
public class DbSeeder(ApplicationDbContext dbContext, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
{
    const string PasswordDefault = "A1b2C3!";
    public async Task SeedAsync()
    {
        await RolesAsync();
        await UsersAsync();
    }

    private async Task RolesAsync()
    {
        if (dbContext.Roles.Any())
            return;

        await roleManager.CreateAsync(new IdentityRole("Feut"));            // Ziet open events
        await roleManager.CreateAsync(new IdentityRole("Schacht"));         // Ziet open + gesloten + schachten events
        await roleManager.CreateAsync(new IdentityRole("Commilitones"));    // Ziet open + gesloten events
        await roleManager.CreateAsync(new IdentityRole("Praesidium"));      // Ziet open + gesloten + schachten events
        await roleManager.CreateAsync(new IdentityRole("Hmdl"));            // Media + Event + Sponsor + Admin-stuff = ICT + Praeses (Admin)
        await roleManager.CreateAsync(new IdentityRole("MediaEditor"));     // Albums aanpassen
        await roleManager.CreateAsync(new IdentityRole("EventEditor"));     // Events aanpassen
        await roleManager.CreateAsync(new IdentityRole("SponsorEditor"));   // Sponsors aanpassen
    }
    
    private async Task  UsersAsync()
    {
        if (dbContext.Users.Any())
            return;
        
        await dbContext.Roles.ToListAsync();

        var admin = new IdentityUser
        {
            UserName = "admin@example.com",
            Email = "admin@example.com",
            EmailConfirmed = true,
        };
        await userManager.CreateAsync(admin, PasswordDefault);
        
        var secretary = new IdentityUser
        {
            UserName = "secretary@example.com",
            Email = "secretary@example.com",
            EmailConfirmed = true,
        };
        await userManager.CreateAsync(secretary, PasswordDefault);
        
        var technicianAccount1 = new IdentityUser
        {
            UserName = "technician1@example.com",
            Email = "technician1@example.com",
            EmailConfirmed = true,
        };
        await userManager.CreateAsync(technicianAccount1, PasswordDefault);
        
        var technicianAccount2 = new IdentityUser
        {
            UserName = "technician2@example.com",
            Email = "technician2@example.com",
            EmailConfirmed = true,
        };
        await userManager.CreateAsync(technicianAccount2, PasswordDefault);
                
        var user = new IdentityUser
        {
            UserName = "user@example.com",
            Email = "user@example.com",
            EmailConfirmed = true,
        };
        await userManager.CreateAsync(user, PasswordDefault);
        
        await userManager.AddToRoleAsync(admin, "Administrator");
        await userManager.AddToRoleAsync(secretary, "Secretary");
        await userManager.AddToRoleAsync(technicianAccount1, "Technician");
        await userManager.AddToRoleAsync(technicianAccount2, "Technician");

        await dbContext.SaveChangesAsync();
    }
    

    
}