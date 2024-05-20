using Ekid.Infrastructure.Messaging;
using Ekid.Infrastructure.Security;
using Ekid.Infrastructure.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace Ekid.Infrastructure;

public static class Bootstrap
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddCommandQueryDispatcherWithHandlers();
        services.AddTransactionalHandlers();
        services.AddPermissionContainer();
    }
}