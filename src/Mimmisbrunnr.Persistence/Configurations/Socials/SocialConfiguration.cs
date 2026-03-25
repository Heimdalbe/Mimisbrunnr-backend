using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mimmisbrunnr.Domain.Common;

namespace Mimmisbrunnr.Persistence.Configurations.Socials;

internal class SocialConfiguration : EntityConfiguration<Social>
{
    public override void Configure(EntityTypeBuilder<Social> builder)
    {
        base.Configure(builder);
        
        builder.Property(s => s.Url).IsRequired();

        builder.HasOne(s => s.Type).WithMany();
    }
}