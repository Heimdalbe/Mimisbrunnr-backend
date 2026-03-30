using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mimisbrunnr.Domain.Common;

namespace Mimisbrunnr.Persistence.Configurations.Socials;

internal class SocialConfiguration : EntityConfiguration<Social>
{
    public override void Configure(EntityTypeBuilder<Social> builder)
    {
        base.Configure(builder);
        
        builder.Property(s => s.Url).IsRequired();

        builder.HasOne(s => s.Type).WithMany();
    }
}