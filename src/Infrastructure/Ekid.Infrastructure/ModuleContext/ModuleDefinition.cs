using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ekid.Infrastructure.ModuleContext;

public abstract class ModuleDefinition
{
    public abstract string RoutePrefix { get; }
    public abstract void AddModuleComponents(IServiceCollection services, IConfiguration configuration);
    public abstract void MapEndpoints(IEndpointRouteBuilder endpoints);
    public abstract ModuleName Name { get; }
    
    //TODO abstraction for permission registration
}