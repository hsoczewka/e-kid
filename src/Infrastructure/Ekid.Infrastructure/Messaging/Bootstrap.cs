using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Ekid.Infrastructure.Messaging;

internal static class Bootstrap
{
    public static void AddCommandQueryDispatcherWithHandlers(this IServiceCollection services, IEnumerable<Assembly> assemblies)
    {
        services.AddSingleton<ICommandQueryDispatcher, CommandQueryDispatcher>();
        services.Scan(s => s.FromAssemblies(assemblies)
            .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());
        services.Scan(s => s.FromAssemblies(assemblies)
            .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());
    }
}