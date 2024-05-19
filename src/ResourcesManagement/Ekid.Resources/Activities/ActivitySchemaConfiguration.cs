using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ekid.Resources.Activities;

public class ActivitySchemaConfiguration : IEntityTypeConfiguration<Activity>
{
    public void Configure(EntityTypeBuilder<Activity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.TenantId).IsRequired();
        builder.Property(x => x.Description).IsRequired();
        builder.Property(x => x.Type).HasConversion(
            v => v.ToString(),
            v => (ActivityType)Enum.Parse(typeof(ActivityType), v));
        builder.Property(x => x.Duration).HasConversion(
            v => v.Minutes,
            v => TimeSpan.FromMinutes(v));
        builder.Property(x => x.Prices)
            .HasColumnType("jsonb");
    }
}