using Ekid.Infrastructure.Primitives;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ekid.ResourcesManagement.Activities;

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
        builder.OwnsMany<ProductPrice>("Price", priceBuilder =>
        {
            priceBuilder.Property(x => x.ValidFrom).IsRequired();
            priceBuilder.Property(x => x.ValidTo).IsRequired(false);
            priceBuilder.OwnsOne(x => x.Price, moneyBuilder =>
            {
                moneyBuilder.Property(x => x.Amount).IsRequired();
                moneyBuilder.Property(x => x.Currency).IsRequired();
            });
        });
    }
}