using Ekid.Infrastructure.ModuleContext;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ekid.Resources.Api;

public class ResourcesManagementModule : ModuleDefinition
{
    public override string RoutePrefix => "/resources";
    
    public override void AddModuleComponents(IServiceCollection services, IConfiguration configuration)
    {
        throw new NotImplementedException();
    }

    public override void MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        throw new NotImplementedException();
    }

    public override ModuleName Name => ModuleName.Of(GetType());
}