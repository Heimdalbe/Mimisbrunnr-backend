using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mimisbrunnr.Domain.Praesidium;

namespace Mimisbrunnr.Persistence.Configurations.Praesidium;

internal class TermConfiguration : EntityConfiguration<PraesidiumTerm>
{
    public override void Configure(EntityTypeBuilder<PraesidiumTerm> builder)
    {
        base.Configure(builder);

        builder.Property(t => t.Year).IsRequired();
        builder.HasAlternateKey(t => t.Year);
        
        //builder.HasOne(t => t.Year).WithMany();
        builder.HasOne(t => t.Role).WithMany();
        builder.HasOne(t => t.MemberDetails).WithOne();
        builder.HasOne(p => p.Image).WithMany();
    }
}