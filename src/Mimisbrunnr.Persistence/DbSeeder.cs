using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
//using Mimisbrunnr.Domain.Accounts;
using Mimisbrunnr.Domain.Common;
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
    private Image defaultImage;
    
    public async Task SeedAsync()
    {
        await RolesAsync();
        await UsersAsync();
        //await AccountAsync();
        await ImagesAsync();
        await PraesidiumAsync();
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

    private async Task ImagesAsync()
    {
        if (dbContext.Images.Any())
            return;

        defaultImage = new Image("https://i.image.com/aiXnDhm.png", "");
        await dbContext.Images.AddAsync(defaultImage);
        
        await dbContext.SaveChangesAsync();
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

    private async Task AccountAsync()
    {
        if(dbContext.Accounts.Any())
            return;
        
        var users = await dbContext.Users.ToListAsync();
        //users.ForEach(u => dbContext.Accounts.Add(new Account(u.UserName!, u.Email!, u.Id)));
        
        await dbContext.SaveChangesAsync();
    }
    
    private async Task PraesidiumAsync()
    {
        #region Role
        
        if(dbContext.PraesidiumRoles.Any())
            return;
            
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
        var keizer_feest_lan = new PraesidiumRole("Keizer Feest & Lan", "feest-lan@heimdal.be", 9);
        await dbContext.PraesidiumRoles.AddAsync(keizer_feest_lan);

        var ict = new PraesidiumRole("ICT", "ict@heimdal.be", 10);
        await dbContext.PraesidiumRoles.AddAsync(ict);

        await dbContext.SaveChangesAsync();
        
        #endregion
        
        #region MemberDetails
        
        if(dbContext.MemberDetails.Any())
            return;

        var p24 = new MemberDetails("Hayley", "Rasschaert", "", "");
        dbContext.MemberDetails.Add(p24);
        var p25 = new MemberDetails("Seppe", "Landtsheer", "67", "100000000000 uur op fortnite");
        dbContext.MemberDetails.Add(p25);
        var vp24 = new MemberDetails("Reina", "Tanghe", "", "");
        dbContext.MemberDetails.Add(vp24);
        var q25 = new MemberDetails("Karsten", "Depoorter", "I like Money", "");
        dbContext.MemberDetails.Add(q25);
        var se24 = new MemberDetails("Tyra", "Bourgeois", "", "");
        dbContext.MemberDetails.Add(se24);
        var se25 = new MemberDetails("Maxe", "Adams", "", "");
        dbContext.MemberDetails.Add(se25);
        var pr25 = new MemberDetails("Zeaya", "Nys", "", "");
        dbContext.MemberDetails.Add(pr25);
        var m24 = new MemberDetails("Britt", "Emanuel", "", "");
        dbContext.MemberDetails.Add(m24);
        var m25 = new MemberDetails("Axelle", "Ducouran", "", "");
        dbContext.MemberDetails.Add(m25);
        var st24 = new MemberDetails("Diede", "Devriendt", "", "");
        dbContext.MemberDetails.Add(st24);
        var st25 = new MemberDetails("Simon", "Tytgat", "", "");
        dbContext.MemberDetails.Add(st25);
        var c24 = new MemberDetails("Kirsten", "Pype", "", "");
        dbContext.MemberDetails.Add(c24);
        var c25 = new MemberDetails("Richardo", "De Blust", "", "");
        dbContext.MemberDetails.Add(c25);
        var sp25 = new MemberDetails("Alejandro", "De Bruyne", "", "Kan een koprol doen");
        dbContext.MemberDetails.Add(sp25);
        var fl24 = new MemberDetails("Tanhuy", "Montaine", "", "");
        dbContext.MemberDetails.Add(fl24);
        var fl25 = new MemberDetails("Richy", "Rahman", "", "");
        dbContext.MemberDetails.Add(fl25);
        var i24 = new MemberDetails("Aaron", "Vandeweghe", "", "");
        dbContext.MemberDetails.Add(i24);
        var i25 = new MemberDetails("Yoran", "Ollevier", "", "2000 uur in BG3");
        dbContext.MemberDetails.Add(i25);
        
        await dbContext.SaveChangesAsync();
        #endregion
        
        #region Term
        if(dbContext.PraesidiumTerms.Any())
            return;

        dbContext.PraesidiumTerms.Add(new PraesidiumTerm(p24, defaultImage, praeses, 2024));
        dbContext.PraesidiumTerms.Add(new PraesidiumTerm(p25, defaultImage, praeses, 2025));
        
        dbContext.PraesidiumTerms.Add(new PraesidiumTerm(vp24, defaultImage, vice_praeses, 2024));
        
        dbContext.PraesidiumTerms.Add(new PraesidiumTerm(se25, defaultImage, quaestor, 2024));
        dbContext.PraesidiumTerms.Add(new PraesidiumTerm(q25, defaultImage, quaestor, 2025));
        
        dbContext.PraesidiumTerms.Add(new PraesidiumTerm(se24, defaultImage, secretaris, 2024));
        dbContext.PraesidiumTerms.Add(new PraesidiumTerm(se25, defaultImage, secretaris, 2025));

        dbContext.PraesidiumTerms.Add(new PraesidiumTerm(pr25, defaultImage, pr, 2025));
        
        dbContext.PraesidiumTerms.Add(new PraesidiumTerm(m24, defaultImage, media, 2024));
        dbContext.PraesidiumTerms.Add(new PraesidiumTerm(m25, defaultImage, media, 2025));
        
        dbContext.PraesidiumTerms.Add(new PraesidiumTerm(st24, defaultImage, schachtentemmer, 2024));
        dbContext.PraesidiumTerms.Add(new PraesidiumTerm(st25, defaultImage, schachtentemmer, 2025));
        
        dbContext.PraesidiumTerms.Add(new PraesidiumTerm(c24, defaultImage, cultuur, 2024));
        dbContext.PraesidiumTerms.Add(new PraesidiumTerm(c25, defaultImage, cultuur, 2025));
        
        dbContext.PraesidiumTerms.Add(new PraesidiumTerm(p25, defaultImage, sport, 2024));
        dbContext.PraesidiumTerms.Add(new PraesidiumTerm(sp25, defaultImage, sport, 2025));
        
        dbContext.PraesidiumTerms.Add(new PraesidiumTerm(fl24, defaultImage, keizer_feest_lan, 2024));
        dbContext.PraesidiumTerms.Add(new PraesidiumTerm(fl25, defaultImage, feest_lan, 2025));
        
        dbContext.PraesidiumTerms.Add(new PraesidiumTerm(i24, defaultImage, ict, 2024));
        dbContext.PraesidiumTerms.Add(new PraesidiumTerm(i25, defaultImage, ict, 2025));
        
        await dbContext.SaveChangesAsync();

        #endregion
        
        #region Erelid
        
        dbContext.Erelids.Add(new Erelid(p24, defaultImage));
        
        await dbContext.SaveChangesAsync();
        
        #endregion
        
        #region SuperSchacht
        
        dbContext.SuperSchachts.Add(new SuperSchacht(m24, defaultImage,2023));
        dbContext.SuperSchachts.Add(new SuperSchacht(q25, defaultImage, 2024));

        await dbContext.SaveChangesAsync();

        #endregion
    }
}