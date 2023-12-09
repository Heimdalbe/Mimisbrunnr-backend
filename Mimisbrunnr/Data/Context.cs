using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Mimisbrunnr.Models;

namespace Mimisbrunnr.Data
{
    public class Context : IdentityDbContext
    {
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
        }
    }
}
