using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mimisbrunnr.Domain.Praesidium;

namespace Mimisbrunnr.Persistence.Configurations.Praesidium;

internal class SuperSchachtConfiguration : EntityConfiguration<SuperSchacht>
{
    public override void Configure(EntityTypeBuilder<SuperSchacht> builder)
    {
        base.Configure(builder);

        builder.Property(s => s.Year).IsRequired();
        
        builder.HasOne(s => s.MemberDetails).WithMany();
        builder.HasOne(s => s.Image).WithMany();
    }
}