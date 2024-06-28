using Ekid.Identity.Contracts.Users.Commands;
using Ekid.Identity.Contracts.Users.Queries;
using Ekid.Infrastructure.Messaging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using static Microsoft.AspNetCore.Http.Results;

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
        
        endpoints.MapGet(
                pattern: $"{Route}/accounts",
                handler: async (
                        [FromServices] ICommandQueryDispatcher dispatcher,
                        CancellationToken token)
                    =>
                {
                    var results = await dispatcher.SendAsync(new GetUsers(), token);
                    return results is not null ? Ok(results) : NotFound();
                })
            .Produces<UsersResponse>()
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest);
        
        endpoints.MapPost(
               pattern: $"{Route}/sign-up",
               handler: async (
                       [FromServices] ICommandQueryDispatcher dispatcher,
                       [FromBody] SignUp command,
                       CancellationToken cancellationToken)
                   =>
               {
                   await dispatcher.SendAsync(command, cancellationToken);
               })
           .Produces(StatusCodes.Status201Created)
           .Produces(StatusCodes.Status400BadRequest)
           .AllowAnonymous();
        
        endpoints.MapPost(
                pattern: $"{Route}/sign-in",
                handler: async (
                        [FromServices] ICommandQueryDispatcher dispatcher,
                        [FromBody] SignIn command,
                        CancellationToken cancellationToken)
                    =>
                {
                    await dispatcher.SendAsync(command, cancellationToken);
                    return command.Token;
                })
            .Produces<UserAccessToken>()
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .AllowAnonymous();
        
        return endpoints;
    }
}