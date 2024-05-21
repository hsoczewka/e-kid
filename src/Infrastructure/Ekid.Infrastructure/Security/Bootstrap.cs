using System.Reflection;
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
        var registries = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes())
            .Where(type => typeof(IPermissionRegistry).IsAssignableFrom(type))
            .Where(type => !type.IsAbstract)
            .Where(type => type.IsClass)
            .ToList();

        using var scope = serviceProvider.CreateScope();
        var container = scope.ServiceProvider.GetRequiredService<PermissionContainer>();
        
        foreach (var permissionRegistry in registries.Select(
                     registry => (IPermissionRegistry)Activator.CreateInstance(registry)!))
        {
            permissionRegistry.ConfigurePermissions(container);
        }
    }
}