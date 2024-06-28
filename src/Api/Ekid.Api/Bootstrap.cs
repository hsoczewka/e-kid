using Ekid.Infrastructure;
using Ekid.Infrastructure.ModuleContext;
using Ekid.Infrastructure.Security;

namespace Ekid.Api;

public static class Bootstrap
{
    public static void AddApplicationComponents(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddInfrastructure(configuration);
        services.AddModulesComponents(configuration);
    }

    public static void UseApplicationComponents(this WebApplication app)
    {
        app.UseInfrastructure();
    }
}