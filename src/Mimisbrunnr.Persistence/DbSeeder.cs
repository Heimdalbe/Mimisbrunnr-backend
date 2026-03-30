using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Mimisbrunnr.Domain.Praesidium;

namespace Mimisbrunnr.Persistence;
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
        await PraesidiumRolesAsync();
    }

    private async Task RolesAsync()
    {
        if (dbContext.Roles.Any())
            return;

        await roleManager.CreateAsync(new IdentityRole("Feut"));            // Ziet open events
        await roleManager.CreateAsync(new IdentityRole("Schacht"));         // Ziet open + gesloten + schachten events
        await roleManager.CreateAsync(new IdentityRole("Commilitones"));    // Ziet open + gesloten events
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

        var praeses = new IdentityUser
        {
            UserName = "praeses@heimdal.be",
            Email = "praeses@heimdal.be",
            EmailConfirmed = true,
        };
        await userManager.CreateAsync(praeses, PasswordDefault);
        await userManager.AddToRoleAsync(praeses, "Commilitones");
        await userManager.AddToRoleAsync(praeses, "Hmdl");
        
        var vice_praeses = new IdentityUser
        {
            UserName = "vice-praeses@heimdal.be",
            Email = "vice-praeses@heimdal.be",
            EmailConfirmed = true,
        };
        await userManager.CreateAsync(vice_praeses, PasswordDefault);
        await userManager.AddToRoleAsync(vice_praeses, "Commilitones");
        await userManager.AddToRoleAsync(vice_praeses, "Hmdl");

        var quaestor = new IdentityUser
        {
            UserName = "quaestor@heimdal.be",
            Email = "quaestor@heimdal.be",
            EmailConfirmed = true,
        };
        await userManager.CreateAsync(quaestor, PasswordDefault);
        await userManager.AddToRoleAsync(quaestor, "Commilitones");

        var secretaris = new IdentityUser
        {
            UserName = "secretaris@heimdal.be",
            Email = "secretaris@heimdal.be",
            EmailConfirmed = true,
        };
        await userManager.CreateAsync(secretaris, PasswordDefault);
        await userManager.AddToRoleAsync(secretaris, "Commilitones");

        var pr = new IdentityUser
        {
            UserName = "pr@heimdal.be",
            Email = "pr@heimdal.be",
            EmailConfirmed = true,
        };
        await userManager.CreateAsync(pr, PasswordDefault);
        await userManager.AddToRoleAsync(pr, "Commilitones");
        await userManager.AddToRoleAsync(pr, "SponsorEditor");

        var media = new IdentityUser
        {
            UserName = "media@heimdal.be",
            Email = "media@heimdal.be",
            EmailConfirmed = true,
        };
        await userManager.CreateAsync(media, PasswordDefault);
        await userManager.AddToRoleAsync(media, "Commilitones");
        await userManager.AddToRoleAsync(media, "MediaEditor");
        await userManager.AddToRoleAsync(media, "EventEditor");

        var schachtentemmer = new IdentityUser
        {
            UserName = "schachtentemmer@heimdal.be",
            Email = "schachtentemmer@heimdal.be",
            EmailConfirmed = true,
        };
        await userManager.CreateAsync(schachtentemmer, PasswordDefault);
        await userManager.AddToRoleAsync(schachtentemmer, "Commilitones");
        await userManager.AddToRoleAsync(schachtentemmer, "EventEditor");

        var cultuur = new IdentityUser
        {
            UserName = "cultuur@heimdal.be",
            Email = "cultuur@heimdal.be",
            EmailConfirmed = true,
        };
        await userManager.CreateAsync(cultuur, PasswordDefault);
        await userManager.AddToRoleAsync(cultuur, "Commilitones");
        await userManager.AddToRoleAsync(cultuur, "EventEditor");
        
        var sport = new IdentityUser
        {
            UserName = "sport@heimdal.be",
            Email = "sport@heimdal.be",
            EmailConfirmed = true,
        };
        await userManager.CreateAsync(sport, PasswordDefault);
        await userManager.AddToRoleAsync(sport, "Commilitones");
        await userManager.AddToRoleAsync(sport, "EventEditor");
        
        var feest_lan = new IdentityUser
        {
            UserName = "feest-lan@heimdal.be",
            Email = "feest-lan@heimdal.be",
            EmailConfirmed = true,
        };
        await userManager.CreateAsync(feest_lan, PasswordDefault);
        await userManager.AddToRoleAsync(feest_lan, "Commilitones");
        await userManager.AddToRoleAsync(feest_lan, "EventEditor");
        
        var ict = new IdentityUser
        {
            UserName = "ict@heimdal.be",
            Email = "ict@heimdal.be",
            EmailConfirmed = true,
        };
        await userManager.CreateAsync(ict, PasswordDefault);
        await userManager.AddToRoleAsync(ict, "Commilitones");
        await userManager.AddToRoleAsync(ict, "Hmdl");

        await dbContext.SaveChangesAsync();
    }

    private async Task PraesidiumRolesAsync()
    {
        var praeses = new PraesidiumRole("Praeses", "praeses@heimdal.be", 0);
        await dbContext.PraesidiumRoles.AddAsync(praeses);
        
        var vice_praeses = new PraesidiumRole("Vice-Praeses", "vice-praeses@heimdal.be", 1);
        await dbContext.PraesidiumRoles.AddAsync(vice_praeses);

        var quaestor = new PraesidiumRole("Quaestor", "quaestor@heimdal.be", 2);
        await dbContext.PraesidiumRoles.AddAsync(quaestor);

        var secretaris = new PraesidiumRole("Secretaris", "secretaris@heimdal.be", 3);
        await dbContext.PraesidiumRoles.AddAsync(secretaris);

        var pr = new PraesidiumRole("PR", "pr@heimdal.be", 4);
        await dbContext.PraesidiumRoles.AddAsync(pr);

        var media = new PraesidiumRole("Media", "media@heimdal.be", 5);
        await dbContext.PraesidiumRoles.AddAsync(media);

        var schachtentemmer = new PraesidiumRole("Schachtentemmer", "schachtentemmer@heimdal.be", 6);
        await dbContext.PraesidiumRoles.AddAsync(schachtentemmer);

        var cultuur = new PraesidiumRole("Cultuur", "cultuur@heimdal.be", 7);
        await dbContext.PraesidiumRoles.AddAsync(cultuur);

        var sport = new PraesidiumRole("Sport", "sport@heimdal.be", 8);
        await dbContext.PraesidiumRoles.AddAsync(sport);

        var feest_lan = new PraesidiumRole("Feest & Lan", "feest-lan@heimdal.be", 9);
        await dbContext.PraesidiumRoles.AddAsync(feest_lan);

        var ict = new PraesidiumRole("ICT", "ict@heimdal.be", 10);
        await dbContext.PraesidiumRoles.AddAsync(ict);

        await dbContext.SaveChangesAsync();
    }
}