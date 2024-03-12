using Ekid.Activities.CreateActivity;
using Ekid.Activities.GetActivity;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Ekid.Activities;

public static class Bootstrap
{
    public static void AddActivitiesComponents(this IServiceCollection services)
        => services.AddSingleton<InMemoryActivityRepository>();

    public static IEndpointRouteBuilder UseActivitiesEndpoints(this IEndpointRouteBuilder endpoints)
        => endpoints
            .UseCreateActivityEndpoint()
            .UseGetActivityEndpoint();
}