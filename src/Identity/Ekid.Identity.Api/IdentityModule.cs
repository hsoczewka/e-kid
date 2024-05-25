
using System.Reflection;
using Ekid.Identity.Permissions;
using Ekid.Infrastructure.ModuleContext;
using Ekid.Infrastructure.Security;
using Microsoft.AspNetCore.Builder;
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
        services.AddIdentityComponents(configuration);
        services.AddSingleton<IPermissionRegistry, Contracts.Security.Permissions>();
    }

    public override void MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup(RoutePrefix);
        group.UsePermissionsEndpoints();
    }
    
    public override ModuleName Name => ModuleName.Of(GetType());
}