using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ekid.Identity.Users;

public class UserAccountEntityConfiguration : IEntityTypeConfiguration<UserAccount>
{
    public void Configure(EntityTypeBuilder<UserAccount> builder)
    {
        builder.ToTable("user_accounts");
        builder.Property<UserId>(x => x.Id)
            .HasConversion(x => x.Id, x => new UserId(x))
            .HasColumnName("UserId");
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.Email).IsUnique();
        builder.Property(x => x.Email)
            .HasConversion(x => x.Value, x => new Email(x))
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(x => x.Role).IsRequired()
            .HasConversion(x => x.Value, x => new UserRole(x));
        builder.Property(x => x.Tenants).HasColumnType("jsonb");
        builder.Property(x => x.IsActive).IsRequired();
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.FirstName).HasMaxLength(150);
        builder.Property(x => x.LastName).HasMaxLength(150);
        builder.Property(x => x.Permissions).HasColumnType("jsonb");
        builder.Property("_version").HasColumnName("Version").IsConcurrencyToken();
    }
}