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
                pattern: "api/activities",
                handler: async (
                        [FromServices] InMemoryActivityRepository repository,
                        CreateActivity command,
                        CancellationToken ct)
                    =>
                {
                    var activity = new Activity(Guid.NewGuid(), Guid.NewGuid(),  command.Description, ActivityType.Diagnosis,
                        TimeSpan.FromMinutes(command.Duration), new Prices(new List<ProductPrice>()));
                    await repository.SaveAsync(activity);
                    
                    return Created($"/api/activities/{activity.Id}", activity.Id);
                    
                })
            .Produces(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest);
        
        endpoints.MapGet(
                pattern: "api/activities",
                handler: async (
                        [FromServices] InMemoryActivityRepository repository,
                        CancellationToken ct)
                    =>
                {
                    var results = await repository.GetAllAsync();
                    return results.Any() ? Ok(results) : NotFound();
                })
            .Produces<List<Activity>>()
            .Produces(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest);
        
        endpoints.MapGet(
                pattern: "api/activities/{id:guid}",
                handler: async (
                        [FromServices] InMemoryActivityRepository repository,
                        Guid id,
                        CancellationToken ct)
                    =>
                {
                    var result = await repository.GetAsync(id);
                    return result != null ? Ok(result) : NotFound();
                })
            .Produces<Activity?>()
            .Produces(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest);

        return endpoints;
    }
}