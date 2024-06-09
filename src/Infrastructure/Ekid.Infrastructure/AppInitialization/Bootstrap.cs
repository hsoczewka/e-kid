namespace Ekid.Infrastructure.AppInitialization;

public static class Bootstrap
{
    public static void RegisterComponentInitializer<TInitializer>(this IServiceCollection services)
        where TInitializer : class, IComponentInitializer
    {
        services.AddScoped<IComponentInitializer, TInitializer>();
    }
}