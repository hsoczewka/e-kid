
using Ekid.Identity.Permissions;
using Ekid.Infrastructure.ModuleContext;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ekid.Identity.Api;

public class IdentityModule : ModuleDefinition
{
    public override string RoutePrefix => "/identity";
    
    public override void AddModuleComponents(IServiceCollection services, IConfiguration configuration)
    {
        services.AddPermissionsComponents();
    }

    public override void MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.UsePermissionsEndpoints();
    }

    public override ModuleName Name => ModuleName.Of(GetType());
}