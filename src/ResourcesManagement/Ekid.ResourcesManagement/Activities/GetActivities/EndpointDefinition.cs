using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using static Microsoft.AspNetCore.Http.Results;

namespace Ekid.ResourcesManagement.Activities.GetActivities;

internal static class EndpointDefinition
{
    internal static IEndpointRouteBuilder UseGetActivitiesEndpoint(this IEndpointRouteBuilder endpoints)
    {
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

        return endpoints;
    }
}