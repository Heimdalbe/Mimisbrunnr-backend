using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Mimisbrunnr.Domain.Account;
using Mimisbrunnr.Domain.Album;
using Mimisbrunnr.Domain.Common;
using Mimisbrunnr.Domain.Event;
using Mimisbrunnr.Domain.Praesidium;
using Mimisbrunnr.Domain.Sponsor;

namespace Mimisbrunnr.Persistence;

/// <summary>
/// Entrance to the database, inherits from IdentityDbContext and is basically a Unit Of Work and Repository pattern combined.
/// A <see cref="DbSet{TEntity}"/> is a repository for a specific type of entity.
/// The <see cref="ApplicationDbContext"/> is the Unit Of Work pattern
/// Will look very similar when switching database providers.
/// See https://hogent-web.github.io/csharp/chapters/09/slides/index.html#1
/// See https://enterprisecraftsmanship.com/posts/should-you-abstract-database/
/// </summary>
/// <param name="opts"></param>
public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> opts) : IdentityDbContext<IdentityUser>(opts)
{
    public DbSet<Account> Accounts => Set<Account>();
    public DbSet<Album> Albums => Set<Album>();
    public DbSet<Image> Images => Set<Image>();
    public DbSet<Social> Socials => Set<Social>();
    public DbSet<SocialType> SocialTypes => Set<SocialType>();
    public DbSet<Event> Events => Set<Event>();
    public DbSet<MemberDetails> MemberDetails => Set<MemberDetails>();
    public DbSet<PraesidiumRole> PraesidiumRoles => Set<PraesidiumRole>();
    public DbSet<PraesidiumTerm> PraesidiumTerms => Set<PraesidiumTerm>();
    public DbSet<Erelid> Erelids => Set<Erelid>();
    public DbSet<LustrumLid> LustrumLids => Set<LustrumLid>();
    public DbSet<SuperSchacht> SuperSchachts => Set<SuperSchacht>();
    public DbSet<Sponsor> Sponsors => Set<Sponsor>();
    
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        // All columns in the database have a maxlength of 4000.
        // in NVARACHAR 4000 is the maximum length that can be indexed by a database.
        // Some columns need more length, but these can be set on the configuration level for that Entity in particular.
        configurationBuilder.Properties<string>().HaveMaxLength(4_000);
        // All decimals columns should have 2 digits after the comma
        configurationBuilder.Properties<decimal>().HavePrecision(18, 2);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Applying all types of IEntityTypeConfiguration in the Persistence project.
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
