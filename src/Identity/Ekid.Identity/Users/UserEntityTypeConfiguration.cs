using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ekid.Identity.Users;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.TenantId).IsRequired();
        builder.Property(x => x.Email).IsRequired();
        builder.Property(x => x.Login).IsRequired();
        builder.Property(x => x.FirstName).IsRequired();
        builder.Property(x => x.LastName).IsRequired();
        builder.Property(x => x.Password).IsRequired();
        builder.Property(x => x.Role).IsRequired()
            .HasConversion(x => x.Value, x => new UserRole(x));
        builder.Property(x => x.IsActive).IsRequired();
    }
}