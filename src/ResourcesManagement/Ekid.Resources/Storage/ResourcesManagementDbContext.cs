using Ekid.Resources.Activities;
using Microsoft.EntityFrameworkCore;

namespace Ekid.Resources.Storage;

public class ResourcesManagementDbContext : DbContext
{
    public const string Schema = "resources";
    
    public DbSet<Activity> Activities { get; set; }

    public ResourcesManagementDbContext(DbContextOptions<ResourcesManagementDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schema);
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}