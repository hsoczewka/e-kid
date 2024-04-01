using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using static Microsoft.AspNetCore.Http.Results;

namespace Ekid.ResourcesManagement.Activities.CreateActivity;

internal static class EndpointDefinition
{
    internal static IEndpointRouteBuilder UseCreateActivityEndpoint(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost(
                pattern: "api/activities",
                handler: async (
                        [FromServices] InMemoryActivityRepository repository,
                        Contracts.Activities.Commands.CreateActivity command,
                        CancellationToken ct)
                    =>
                {
                    var activity = new Activity(Guid.NewGuid(), command.Description, ActivityType.Diagnosis,
                        command.Duration, command.Price);
                    await repository.SaveAsync(activity);
                    
                    return Created($"/api/activities/{activity.Id}", activity.Id);
                    
                })
            .Produces(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest);

        return endpoints;
    }
}