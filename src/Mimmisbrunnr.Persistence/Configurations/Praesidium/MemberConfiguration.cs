using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mimmisbrunnr.Domain.Praesidium;

namespace Mimmisbrunnr.Persistence.Configurations.Praesidium;

internal class EventConfiguration : EntityConfiguration<PraesidiumMember>
{
    public override void Configure(EntityTypeBuilder<PraesidiumMember> builder)
    {
        base.Configure(builder);
        
        builder.Property(p => p.FirstName).HasMaxLength(50).IsRequired();
        builder.Property(p => p.LastName).HasMaxLength(50).IsRequired();
        builder.Property(p => p.Quote).HasMaxLength(200);
        builder.Property(p => p.Trivia).HasMaxLength(200);

        builder.HasOne(p => p.Image).WithMany();
        builder.HasMany(p => p.Socials).WithOne();
    }
}