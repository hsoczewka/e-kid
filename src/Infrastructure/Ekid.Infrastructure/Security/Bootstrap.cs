using Microsoft.Extensions.DependencyInjection;

namespace Ekid.Infrastructure.Security;

public static class Bootstrap
{
    public static void AddPermissionContainer(this IServiceCollection services)
    {
        services.AddSingleton(new PermissionContainer());
    }

    public static void RegisterAllPermissions(this IServiceProvider serviceProvider)
    {
        //TODO scan all assemblies for IPermissionRegistry implementation and add found items to the permissions container. 
    }
}