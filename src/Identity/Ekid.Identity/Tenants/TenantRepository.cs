using Microsoft.EntityFrameworkCore;

namespace Ekid.Identity.Tenants;

public class TenantRepository
{
    private readonly IdentityDbContext _identityDbContext;

    public TenantRepository(IdentityDbContext identityDbContext)
    {
        _identityDbContext = identityDbContext;
    }

    public async Task AddAsync(Tenant tenant, CancellationToken cancellationToken)
    {
        await _identityDbContext.Tenants.AddAsync(tenant, cancellationToken);
    }

    public async Task<TenantSummary?> FindSummaryByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var tenant = await _identityDbContext.Tenants.AsNoTracking().SingleOrDefaultAsync(x => x.Id.Id == id, cancellationToken);
        return tenant is not null ? TenantSummary.Create(tenant) : default;
    }
    
    public async Task<TenantSummary?> FindSummaryByNameAsync(string name, CancellationToken cancellationToken)
    {
        var tenant = await _identityDbContext.Tenants.AsNoTracking().SingleOrDefaultAsync(x => x.Name == name, cancellationToken);
        return tenant is not null ? TenantSummary.Create(tenant) : default;
    }
    
    public async Task<Tenant?> GetByNameAsync(string name, CancellationToken cancellationToken)
    {
        return await _identityDbContext.Tenants.SingleOrDefaultAsync(x => x.Name == name, cancellationToken);
    }
    
    public async Task<Tenant?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _identityDbContext.Tenants.SingleOrDefaultAsync(x => x.Id.Id == id, cancellationToken);
    }
}