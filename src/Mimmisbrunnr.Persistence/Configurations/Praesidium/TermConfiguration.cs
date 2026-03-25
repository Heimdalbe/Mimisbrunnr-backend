using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mimmisbrunnr.Domain.Praesidium;

namespace Mimmisbrunnr.Persistence.Configurations.Praesidium;

internal class TermConfiguration : EntityConfiguration<PraesidiumTerm>
{
    public override void Configure(EntityTypeBuilder<PraesidiumTerm> builder)
    {
        base.Configure(builder);

        builder.Property(t => t.Year).IsRequired();
        builder.HasAlternateKey(t => t.Year);
        
        //builder.HasOne(t => t.Year).WithMany();
        builder.HasOne(t => t.Role).WithMany();
        builder.HasOne(t => t.Member).WithOne();
    }
}