using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mimmisbrunnr.Domain.Praesidium;

namespace Mimmisbrunnr.Persistence.Configurations.Praesidium;

internal class EreLidConfiguration : EntityConfiguration<Erelid>
{
    public override void Configure(EntityTypeBuilder<Erelid> builder)
    {
        base.Configure(builder);

        builder.HasOne(e => e.MemberDetails).WithMany();
        builder.HasOne(e => e.Image).WithMany();
    }
}