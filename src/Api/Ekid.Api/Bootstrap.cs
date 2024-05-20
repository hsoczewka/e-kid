using Ekid.Infrastructure;
using Ekid.Infrastructure.ModuleContext;

namespace Ekid.Api;

public static class Bootstrap
{
    public static void AddApplicationComponents(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddInfrastructure();
        services.AddModulesComponents(configuration);
    }
}