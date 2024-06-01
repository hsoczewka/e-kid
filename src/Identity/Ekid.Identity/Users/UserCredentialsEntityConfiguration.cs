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
        builder.Property(x => x.Email)
            .HasMaxLength(320)
            .IsRequired();
        builder.Property(x => x.Login)
            .HasMaxLength(50)
            .IsRequired();
        builder.Property(x => x.Password)
            .HasMaxLength(256)
            .IsRequired();
        builder.Property("_version").HasColumnName("Version").IsConcurrencyToken();
    }
}