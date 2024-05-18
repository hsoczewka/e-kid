using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using static Microsoft.AspNetCore.Http.Results;

namespace Ekid.Identity.Permissions;

internal static class Endpoints
{
    private static string Route => "permissions";
    
    internal static IEndpointRouteBuilder UsePermissionsEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet(
                pattern: Route,
                handler: async (
                        [FromServices] IPermissionsProvider permissionsProvider,
                        CancellationToken cancellationToken)
                    =>
                {
                    return await permissionsProvider.GetAvailablePermissions(cancellationToken);
                })
            .Produces<List<Infrastructure.Security.Permission>>()
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest);

        return endpoints;
    }
    
}