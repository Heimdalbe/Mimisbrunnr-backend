using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mimisbrunnr.Domain.Common;

namespace Mimisbrunnr.Persistence.Configurations.Socials;

internal class SocialTypeConfiguration: EntityConfiguration<SocialType>
{
    public override void Configure(EntityTypeBuilder<SocialType> builder)
    {
        base.Configure(builder);

        builder.Property(st => st.Name).HasMaxLength(50).IsRequired();
        
        builder.HasOne(st => st.Icon).WithMany();
    }
}