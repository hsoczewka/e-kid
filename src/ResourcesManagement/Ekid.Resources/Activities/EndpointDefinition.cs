using Ekid.Infrastructure.CallContext;
using Ekid.Infrastructure.Primitives;
using Ekid.Resources.Activities.DAL;
using Ekid.Resources.Contracts.Activities.Commands;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using static Microsoft.AspNetCore.Http.Results;

namespace Ekid.Resources.Activities;

internal static class EndpointDefinition
{
    internal static IEndpointRouteBuilder UseActivityEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost(
                pattern: "activities",
                handler: async (
                        [FromServices] InMemoryActivityRepository repository,
                        CreateActivity command,
                        CancellationToken ct)
                    =>
                {
                    var activity = new Activity(Guid.NewGuid(), Guid.NewGuid(), command.Description,
                        ActivityType.Diagnosis,
                        TimeSpan.FromMinutes(command.Duration), new Prices(new List<ProductPrice>()));
                    await repository.SaveAsync(activity);

                    return Created($"/api/activities/{activity.Id}", activity.Id);

                })
            .Produces(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .RequireTenantId();

        endpoints.MapGet(
                pattern: "activities",
                handler: async (
                        [FromServices] InMemoryActivityRepository repository,
                        CancellationToken ct)
                    =>
                {
                    var results = await repository.GetAllAsync();
                    return results.Any() ? Ok(results) : NotFound();
                })
            .Produces<List<Activity>>()
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest)
            .RequireTenantId();

        endpoints.MapGet(
                pattern: "api/activities/{activityId:guid}",
                handler: async (
                        [FromServices] InMemoryActivityRepository repository,
                        [FromRoute] Guid activityId,
                        CancellationToken ct)
                    =>
                {
                    var result = await repository.GetAsync(activityId);
                    return result != null ? Ok(result) : NotFound();
                })
            .Produces<Activity?>()
            .Produces(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .RequireTenantId();

        return endpoints;
    }
}