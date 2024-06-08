using Ekid.Infrastructure.AppInitialization;
using Microsoft.EntityFrameworkCore;

namespace Ekid.Identity.Tenants;

internal sealed class TenantInitializer : IComponentInitializer
{
    private readonly IdentityDbContext _identityDbContext;

    public TenantInitializer(IdentityDbContext identityDbContext)
    {
        _identityDbContext = identityDbContext;
    }

    public async Task InitializeAsync(CancellationToken token)
    {
        if (await _identityDbContext.Tenants.AnyAsync(cancellationToken: token))
        {
            return;
        }

        await AddDefaultAsync();
        await _identityDbContext.SaveChangesAsync(token);
    }

    private async Task AddDefaultAsync()
    {
        await _identityDbContext.Tenants.AddAsync(
            new Tenant(TenantId.New(), 
                "ekid", 
                "Maintenance tenant", 
                true));
    }
}