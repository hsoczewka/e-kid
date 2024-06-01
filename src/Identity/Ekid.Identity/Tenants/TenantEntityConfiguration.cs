using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ekid.Identity.Tenants;

public class TenantEntityConfiguration : IEntityTypeConfiguration<Tenant>
{
    public void Configure(EntityTypeBuilder<Tenant> builder)
    {
        builder.ToTable("tenants");
        builder.Property<TenantId>(x => x.Id)
            .HasConversion(x => x.Id, x => new TenantId(x))
            .HasColumnName("TenantId");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name)
            .HasMaxLength(50)
            .IsRequired();
        builder.Property(x => x.Description)
            .HasMaxLength(250)
            .IsRequired();
        builder.Property(x => x.IsActive).IsRequired();
    }
}