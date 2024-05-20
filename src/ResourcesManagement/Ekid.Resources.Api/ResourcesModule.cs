using System.Diagnostics;
using Ekid.Infrastructure.ModuleContext;
using Ekid.Resources.Activities;
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
    }

    public override void MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var activities = endpoints.MapGroup(RoutePrefix);
        activities.UseActivitiesEndpoints();
    }

    public override ModuleName Name => ModuleName.Of(GetType());
}