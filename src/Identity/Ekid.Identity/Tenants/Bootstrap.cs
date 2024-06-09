using Ekid.Infrastructure.AppInitialization;
using Microsoft.Extensions.DependencyInjection;

namespace Ekid.Identity.Tenants;

public static class Bootstrap
{
    public static void AddTenantsComponents(this IServiceCollection services)
    {
        services.AddScoped<TenantRepository>();
        services.RegisterComponentInitializer<TenantInitializer>();
    }
}