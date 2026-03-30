using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mimisbrunnr.Domain.Common;

namespace Mimisbrunnr.Persistence.Configurations.Images;

internal class ImageConfiguration : EntityConfiguration<Image>
{
    public override void Configure(EntityTypeBuilder<Image> builder)
    {
        base.Configure(builder);
        
        builder.Property(i => i.Description).HasMaxLength(250);
        
        builder.Property(i => i.Url).HasMaxLength(100);
    }
}