using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mimisbrunnr.Domain.Membership;

namespace Mimisbrunnr.Persistence.Configurations.Membership;

internal class MembershipFeesConfiguration : IEntityTypeConfiguration<MembershipFees>
{
    public void Configure(EntityTypeBuilder<MembershipFees> builder)
    {
        builder.ToTable(nameof(MembershipFees));
        builder.HasKey(f => f.Id);
        builder.Property(f => f.Id).ValueGeneratedNever();
        builder.HasData(new MembershipFees { Id = 1, FirstYearFee = 12m, RenewalFee = 7m });
    }
}
