using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ekid.Identity.Permissions;

public class AssignedPermissionsEntityConfiguration : IEntityTypeConfiguration<AssignedPermissions>
{
    public void Configure(EntityTypeBuilder<AssignedPermissions> builder)
    {
        builder.ToTable("assigned_permissions");
        builder.HasKey(x => x.UserId);
        builder.Property(x => x.TenantId).IsRequired();
        builder.Property(x => x.Permissions).HasColumnType("jsonb");
    }
}