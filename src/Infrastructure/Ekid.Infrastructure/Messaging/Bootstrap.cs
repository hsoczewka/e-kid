using System.Reflection;
using Ekid.Infrastructure.Attributes;
using Microsoft.Extensions.DependencyInjection;

namespace Ekid.Infrastructure.Messaging;

internal static class Bootstrap
{
    public static void AddCommandQueryDispatcherWithHandlers(this IServiceCollection services, IEnumerable<Assembly> assemblies)
    {
        services.AddSingleton<ICommandQueryDispatcher, CommandQueryDispatcher>();
        services.Scan(s => s.FromAssemblies(assemblies)
            .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>))
                .WithoutAttribute<ExcludeFromAutoRegistrationAttribute>())
            .AsImplementedInterfaces()
            .WithScopedLifetime());
        services.Scan(s => s.FromAssemblies(assemblies)
            .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>))
                .WithoutAttribute<ExcludeFromAutoRegistrationAttribute>())
            .AsImplementedInterfaces()
            .WithScopedLifetime());
    }
}