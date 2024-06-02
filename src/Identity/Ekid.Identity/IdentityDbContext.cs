using Ekid.Identity.Users;
using Microsoft.EntityFrameworkCore;

namespace Ekid.Identity;

public class IdentityDbContext : DbContext
{
    public const string Schema = "identity";
    public DbSet<UserAccount> UsersAccounts { get; set; }
    public DbSet<UserCredentials> UsersCredentials { get; set; }

    public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schema);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IdentityDbContext).Assembly);
    }
}