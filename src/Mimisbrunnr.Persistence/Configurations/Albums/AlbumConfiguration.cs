using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mimisbrunnr.Domain.Album;

namespace Mimisbrunnr.Persistence.Configurations.Albums;

internal class AlbumConfiguration : EntityConfiguration<Album>
{
    public override void Configure(EntityTypeBuilder<Album> builder)
    {
        base.Configure(builder);
        
        builder.Property(a => a.Name).HasMaxLength(100).IsRequired();
        builder.Property(a => a.Year).IsRequired();
        builder.Property(a => a.Description).HasMaxLength(500);
        builder.Property(a => a.CoverImage);
        builder.HasMany(a => a.Images).WithOne();
    }
}