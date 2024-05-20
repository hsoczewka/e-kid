using System.Reflection;
using Ekid.Infrastructure.Attributes;
using Microsoft.Extensions.DependencyInjection;

namespace Ekid.Infrastructure.Messaging;

internal static class Bootstrap
{
    public static void AddCommandQueryDispatcherWithHandlers(this IServiceCollection services)
    {
        services.AddSingleton<ICommandQueryDispatcher, CommandQueryDispatcher>();
        services.Scan(s => s.FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
            .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>))
                .WithoutAttribute<ExcludeFromAutoRegistrationAttribute>())
            .AsImplementedInterfaces()
            .WithScopedLifetime());
        services.Scan(s => s.FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
            .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>))
                .WithoutAttribute<ExcludeFromAutoRegistrationAttribute>())
            .AsImplementedInterfaces()
            .WithScopedLifetime());
    }
}