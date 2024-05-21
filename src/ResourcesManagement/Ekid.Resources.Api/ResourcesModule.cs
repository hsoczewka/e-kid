using Ekid.Infrastructure.ModuleContext;
using Ekid.Infrastructure.Security;
using Ekid.Resources.Activities;
using Ekid.Resources.Contracts.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ekid.Resources.Api;

public class ResourcesModule : ModuleDefinition
{
    public override string RoutePrefix => "/resources";
    
    public override void AddModuleComponents(IServiceCollection services, IConfiguration configuration)
    {
        services.AddActivitiesComponents();
        services.AddSingleton<IPermissionRegistry, Permissions>();
    }

    public override void MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup(RoutePrefix);
        group.UseActivitiesEndpoints();
    }
    
    public override ModuleName Name => ModuleName.Of(GetType());
}