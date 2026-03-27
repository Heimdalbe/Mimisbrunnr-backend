using System.Net.Mail;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mimmisbrunnr.Domain.Praesidium;

namespace Mimmisbrunnr.Persistence.Configurations.Praesidium;

internal class RoleConfiguration : EntityConfiguration<PraesidiumRole>
{
    public override void Configure(EntityTypeBuilder<PraesidiumRole> builder)
    {
        base.Configure(builder);
        
        builder.Property(r => r.Name).HasMaxLength(50).IsRequired();
        builder.Property(r => r.Email).HasConversion(m => m.Address, value => new MailAddress(value));
        builder.Property(r => r.Order).IsRequired();
    }

}