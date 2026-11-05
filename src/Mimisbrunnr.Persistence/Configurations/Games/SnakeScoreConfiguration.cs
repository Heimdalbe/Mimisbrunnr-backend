using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mimisbrunnr.Domain.Games;

namespace Mimisbrunnr.Persistence.Configurations.Games;

internal class SnakeScoreConfiguration : IEntityTypeConfiguration<SnakeScore>
{
    public void Configure(EntityTypeBuilder<SnakeScore> builder)
    {
        builder.ToTable("SnakeScores");
        builder.HasKey(s => s.Id);
        builder.Property(s => s.UserId).HasMaxLength(255);
        builder.HasOne<IdentityUser>().WithMany().HasForeignKey(s => s.UserId).OnDelete(DeleteBehavior.Cascade);
        builder.HasIndex(s => new { s.Width, s.Height, s.UserId, s.Score });
    }
}
