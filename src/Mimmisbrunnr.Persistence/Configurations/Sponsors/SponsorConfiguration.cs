using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mimmisbrunnr.Domain.Sponsor;

namespace Mimmisbrunnr.Persistence.Configurations.Sponsors;

internal class SponsorConfiguration : EntityConfiguration<Sponsor>
{
    public override void Configure(EntityTypeBuilder<Sponsor> builder)
    {
        base.Configure(builder);
        
        builder.Property(s => s.Name).HasMaxLength(100).IsRequired();
        builder.Property(s => s.Order).IsRequired();
        builder.Property(s => s.Benefits).HasMaxLength(200);
        builder.Property(s => s.Website).HasMaxLength(100);
        builder.Property(s => s.Rank);
        builder.Property(s => s.LanSponsorRank);
        
        builder.HasOne(s => s.Logo).WithMany();
        
    }
}