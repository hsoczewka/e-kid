using Ekid.Identity.Contracts.Tenants.Commands;
using Ekid.Infrastructure.Identity.Authorization;
using Ekid.Infrastructure.Messaging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Ekid.Identity.Tenants;

public static class Endpoints
{
    private static string Route => "tenant";
    
    internal static IEndpointRouteBuilder UseTenantEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost(
                pattern: $"{Route}/create" ,
                handler: async (
                        [FromServices] ICommandQueryDispatcher dispatcher,
                        [FromBody] CreateTenant command,
                        CancellationToken cancellationToken)
                    =>
                {
                    await dispatcher.SendAsync(command, cancellationToken);
                })
            .Produces(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest);
        

        return endpoints;
    }
}