using Ekid.Activities.Contracts.Commands;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Ekid.Activities.CreateActivity;

internal static class EndpointDefinition
{
    internal static IEndpointRouteBuilder UseCreateActivityEndpoint(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost(
                pattern: "api/activities",
                handler: async (
                        [FromServices] InMemoryActivityRepository repository,
                        Contracts.Commands.CreateActivity command,
                        CancellationToken ct)
                    =>
                {
                    var activity = new Activity(Guid.NewGuid(), command.Description, ActivityType.Diagnosis,
                        command.Duration, command.Price);
                    await repository.SaveAsync(activity);
                })
            .Produces(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest);

        return endpoints;
    }
}