using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ekid.Identity.Users;

public class UserCredentialsEntityConfiguration : IEntityTypeConfiguration<UserCredentials>
{
    public void Configure(EntityTypeBuilder<UserCredentials> builder)
    {
        builder.ToTable("user_credentials");
        builder.Property<UserId>(x => x.Id)
            .HasConversion(x => x.Id, x => new UserId(x))
            .HasColumnName("UserId");
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.Email).IsUnique();
        builder.Property(x => x.Email)
            .HasConversion(x => x.Value, x => new Email(x))
            .IsRequired()
            .HasMaxLength(100);
        builder.HasIndex(x => x.Login).IsUnique();
        builder.Property(x => x.Login)
            .HasConversion(x => x.Value, x => new Login(x))
            .IsRequired()
            .HasMaxLength(30);
        builder.Property(x => x.Password)
            .HasConversion(x => x.Value, x => new Password(x))
            .IsRequired()
            .HasMaxLength(256);
        builder.Property("_version").HasColumnName("Version").IsConcurrencyToken();
    }
}