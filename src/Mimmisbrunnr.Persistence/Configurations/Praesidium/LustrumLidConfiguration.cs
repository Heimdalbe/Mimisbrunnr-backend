using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mimmisbrunnr.Domain.Praesidium;

namespace Mimmisbrunnr.Persistence.Configurations.Praesidium;

internal class LustrumLidConfiguration : EntityConfiguration<LustrumLid>
{
    public override void Configure(EntityTypeBuilder<LustrumLid> builder)
    {
        base.Configure(builder);

        builder.Property(l => l.Year).IsRequired();
        
        builder.HasOne(l => l.MemberDetails).WithMany();
        builder.HasOne(l => l.Image).WithMany();
    }
}