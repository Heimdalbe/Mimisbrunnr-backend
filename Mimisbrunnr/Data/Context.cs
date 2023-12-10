using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Mimisbrunnr.Models;

namespace Mimisbrunnr.Data
{
    public class Context : IdentityDbContext
    {
        public DbSet<CmsPage> CmsPage { get; set; }
        public DbSet<Album> Album { get; set; }
        public DbSet<Picture> Picture { get; set; }
        public DbSet<PraesidiumFunction> PraesidiumFunction { get; set; }
        public DbSet<PraesidiumMember> PraesidiumMember { get; set; }
        public DbSet<PraesidiumYear> PraesidiumYear { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<DiscordWebhook> Webhooks { get; set; }

        public Context(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            base.OnModelCreating(mb);

            mb.Entity<CmsPage>();
            mb.Entity<Album>();
            
            mb.Entity<Picture>();
            mb.Entity<PraesidiumFunction>();
            mb.Entity<PraesidiumMember>();
            mb.Entity<PraesidiumYear>();
            mb.Entity<Event>()
                .HasOne(e => e.Owner)
                .WithMany()
                ;
            mb.Entity<DiscordWebhook>();
        }
    }
}
