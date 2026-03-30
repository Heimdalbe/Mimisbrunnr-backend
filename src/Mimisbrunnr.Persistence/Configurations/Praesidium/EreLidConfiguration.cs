using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mimisbrunnr.Domain.Praesidium;

namespace Mimisbrunnr.Persistence.Configurations.Praesidium;

internal class EreLidConfiguration : EntityConfiguration<Erelid>
{
    public override void Configure(EntityTypeBuilder<Erelid> builder)
    {
        base.Configure(builder);

        builder.HasOne(e => e.MemberDetails).WithMany();
        builder.HasOne(e => e.Image).WithMany();
    }
}