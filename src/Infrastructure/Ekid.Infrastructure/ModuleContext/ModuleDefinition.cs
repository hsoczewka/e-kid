using System.Reflection;
using Ekid.Infrastructure.Security;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ekid.Infrastructure.ModuleContext;

public abstract class ModuleDefinition
{
    public abstract string RoutePrefix { get; }
    public abstract void AddModuleComponents(IServiceCollection services, IConfiguration configuration);
    public abstract void MapEndpoints(IEndpointRouteBuilder endpoints);
    public abstract ModuleName Name { get; }
}

public static class Modules
{
    private static Dictionary<ModuleName, ModuleDefinition> RegisteredModules = new();

    public static void RegisterModule<TModule>(Func<TModule>? moduleFactory = default) where TModule : ModuleDefinition
    {
        var moduleDefinition = moduleFactory is not null
            ? moduleFactory()
            : Activator.CreateInstance<TModule>();
        
        RegisteredModules.Add(moduleDefinition.Name, moduleDefinition);
    }
    
    public static void AddModulesComponents(this IServiceCollection services, IConfiguration configuration)
    {
        foreach (var module in RegisteredModules.Values)
        {
            module.AddModuleComponents(services, configuration);
        }
    }

    public static void UseModuleEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        foreach (var module in RegisteredModules.Values)
        {
            module.MapEndpoints(endpointRouteBuilder);
        }
    }
}