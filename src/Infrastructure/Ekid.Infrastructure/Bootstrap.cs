using Ekid.Infrastructure.AppInitialization;
using Ekid.Infrastructure.Messaging;
using Ekid.Infrastructure.Security;
using Ekid.Infrastructure.UnitOfWork;

namespace Ekid.Infrastructure;

public static class Bootstrap
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddCommandQueryDispatcherWithHandlers();
        services.AddTransactionalHandlers();
        services.AddPermissionContainer();
        services.AddHostedService<AppInitializer>();
    }
}