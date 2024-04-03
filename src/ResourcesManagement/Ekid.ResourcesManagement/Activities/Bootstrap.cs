using Ekid.ResourcesManagement.Activities.CreateActivity;
using Ekid.ResourcesManagement.Activities.DAL;
using Ekid.ResourcesManagement.Activities.GetActivities;
using Ekid.ResourcesManagement.Activities.GetActivity;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Ekid.ResourcesManagement.Activities;

public static class Bootstrap
{
    public static void AddActivitiesComponents(this IServiceCollection services)
        => services.AddSingleton<InMemoryActivityRepository>();

    public static IEndpointRouteBuilder UseActivitiesEndpoints(this IEndpointRouteBuilder endpoints)
        => endpoints
            .UseCreateActivityEndpoint()
            .UseGetActivityEndpoint()
            .UseGetActivitiesEndpoint();
}