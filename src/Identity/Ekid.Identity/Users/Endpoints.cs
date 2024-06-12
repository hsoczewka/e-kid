using Ekid.Identity.Contracts.Tenants.Commands;
using Ekid.Identity.Contracts.Users.Commands;
using Ekid.Infrastructure.Messaging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Ekid.Identity.Users;

public static class Endpoints
{
    private static string Route => "user";
    
    internal static IEndpointRouteBuilder UseUsersEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost(
                pattern: $"{Route}/account",
                handler: async (
                        [FromServices] ICommandQueryDispatcher dispatcher,
                        [FromBody] CreateUserAccount command,
                        CancellationToken cancellationToken)
                    =>
                {
                    await dispatcher.SendAsync(command, cancellationToken);
                })
            .Produces(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest);
        
        /*endpoints.MapPut(
                pattern: $"{Route}/activate",
                handler: async (
                        [FromServices] ICommandQueryDispatcher dispatcher,
                        [FromBody] ActivateTenant command,
                        CancellationToken cancellationToken)
                    =>
                {
                    await dispatcher.SendAsync(command, cancellationToken);
                })
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest);*/
        
        return endpoints;
    }
}