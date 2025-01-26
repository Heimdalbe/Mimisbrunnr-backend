using Microsoft.EntityFrameworkCore;
using Mimmisbrunnr.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mimmisbrunnr.Infrastructure.Context
{
    public class ImageStoreContext : DbContext
    {
        public ImageStoreContext(DbContextOptions<ImageStoreContext> options) : base(options) { }

        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
