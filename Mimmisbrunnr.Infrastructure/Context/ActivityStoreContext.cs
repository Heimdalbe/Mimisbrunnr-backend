using Microsoft.EntityFrameworkCore;
using Mimmisbrunnr.Domain.Activities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mimmisbrunnr.Infrastructure.Context
{
    public class ActivityStoreContext : DbContext
    {
        public ActivityStoreContext(DbContextOptions<ActivityStoreContext> options): base(options) { }

        public DbSet<Activity> Events { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Activity>()
                .HasOne(e => e.Location)
                .WithMany(l => l.Events);
        }
    }
}
