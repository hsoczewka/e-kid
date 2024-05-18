using Microsoft.Extensions.DependencyInjection;

namespace Ekid.Identity.Permissions;

public static class Bootstrap
{
    public static void AddPermissionsComponents(this IServiceCollection services)
    {
        services.AddScoped<IPermissionsProvider, PermissionsProvider>();
    }
}