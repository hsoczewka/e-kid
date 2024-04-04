using Microsoft.EntityFrameworkCore;

namespace Ekid.ResourcesManagement.Storage;

public class ResourcesManagementDbContext : DbContext
{
    public const string Schema = "resources";

    public ResourcesManagementDbContext(DbContextOptions<ResourcesManagementDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schema);
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}