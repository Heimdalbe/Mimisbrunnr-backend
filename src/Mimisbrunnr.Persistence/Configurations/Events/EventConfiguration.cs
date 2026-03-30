using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mimisbrunnr.Domain.Events;

namespace Mimisbrunnr.Persistence.Configurations.Events;

internal class EventConfiguration : EntityConfiguration<Event>
{
    public override void Configure(EntityTypeBuilder<Event> builder)
    {
        base.Configure(builder);
        
        builder.Property(e => e.Name).IsRequired().HasMaxLength(50);
        builder.Property(e => e.Description).HasMaxLength(200);
        builder.Property(e => e.Location).HasMaxLength(50);
        builder.Property(e => e.Start).HasColumnType("datetime");
        builder.Property(e => e.End).HasColumnType("datetime");
        builder.Property(e => e.EntryFee);
        builder.Property(e => e.ICal);
        builder.Property(e => e.Category);
        builder.Property(e => e.Accessibility);
        builder.Property(e => e.Published);

        builder.HasOne(e => e.Banner).WithMany();
        builder.HasMany(e => e.Sponsors).WithMany();
    }
}