using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mimisbrunnr.Domain.Events;

namespace Mimisbrunnr.Persistence.Configurations.Events;

internal class EventConfiguration : EntityConfiguration<Event>
{
    public override void Configure(EntityTypeBuilder<Event> builder)
    {
        base.Configure(builder);
        
        builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
        builder.Property(e => e.Description).HasMaxLength(2000);
        builder.Property(e => e.Location).HasMaxLength(200);
        builder.Property(e => e.Start).HasColumnType("datetime");
        builder.Property(e => e.End).HasColumnType("datetime");
        builder.Property(e => e.EntryFee);
        builder.Property(e => e.ICal);
        builder.Property(e => e.Category);
        builder.Property(e => e.Accessibility);
        builder.Property(e => e.AllowedRoles)
            .HasColumnType("longtext")
            .HasConversion(
                roles => JsonSerializer.Serialize(roles, (JsonSerializerOptions?)null),
                json => JsonSerializer.Deserialize<List<string>>(json, (JsonSerializerOptions?)null))
            .Metadata.SetValueComparer(new ValueComparer<List<string>?>(
                (a, b) => a == null ? b == null : b != null && a.SequenceEqual(b),
                roles => roles == null ? 0 : roles.Aggregate(0, (hash, role) => HashCode.Combine(hash, role.GetHashCode())),
                roles => roles == null ? null : roles.ToList()));
        builder.Property(e => e.Published);

        builder.HasOne(e => e.Banner).WithMany();
        builder.HasMany(e => e.Sponsors).WithMany();
    }
}