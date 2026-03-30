using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mimisbrunnr.Domain.Praesidium;

namespace Mimisbrunnr.Persistence.Configurations.Praesidium;

internal class YearConfiguration : EntityConfiguration<PraesidiumYear>
{
    public override void Configure(EntityTypeBuilder<PraesidiumYear> builder)
    {
        base.Configure(builder);

        builder.Property(y => y.StartYear);
        builder.Property(y => y.EndYear);
    }
}