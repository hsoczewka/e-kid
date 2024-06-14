using Ekid.Identity.Permissions;
using Ekid.Identity.Tenants;
using Ekid.Identity.Users;
using Ekid.Infrastructure.ModuleContext;
using Ekid.Infrastructure.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ekid.Identity.Api;

public class IdentityModule : ModuleDefinition
{
    public override string RoutePrefix => "/identity";
    
    public override void AddModuleComponents(IServiceCollection services, IConfiguration configuration)
    {
        services.AddIdentityComponents(configuration);
        services.AddSingleton<IPermissionRegistry, Contracts.Security.Permissions>();
    }

    public override void MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup(RoutePrefix);
        group.UsePermissionsEndpoints();
        group.UseTenantEndpoints();
        group.UseUsersEndpoints();
        group.WithTags("identity");
    }
    
    public override ModuleName Name => ModuleName.Of(GetType());
}