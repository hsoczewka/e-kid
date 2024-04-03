using Ekid.ResourcesManagement.Activities.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using static Microsoft.AspNetCore.Http.Results;

namespace Ekid.ResourcesManagement.Activities.GetActivity;

internal static class EndpointDefinition
{
    internal static IEndpointRouteBuilder UseGetActivityEndpoint(this IEndpointRouteBuilder endpoints)
    {
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