using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace Ekid.Infrastructure.Storage;

public static class PostgresConfiguration
{
    public static IServiceCollection AddPostgres<T>(this IServiceCollection services, IConfiguration configuration) where T : DbContext
    {
        var connectionString = configuration.GetConnectionString("Postgres");
        var dataSource = new NpgsqlDataSourceBuilder(connectionString)
            .ConfigureJsonOptions(new JsonSerializerOptions() { IgnoreReadOnlyProperties = true, IgnoreReadOnlyFields = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase})
            .EnableDynamicJson()
            .Build();
        services.AddDbContext<T>(x => x.UseNpgsql(dataSource));
    
        return services;
    }
    
    //replaced by AppInitializer
    public static void EnsureDatabaseCreated(this IServiceProvider serviceProvider)
    {
        var dbContexts = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes())
            .Where(type => typeof(DbContext).IsAssignableFrom(type))
            .Where(type => !type.IsAbstract)
            .Where(type => type != typeof(DbContext))
            .ToList();

        using var scope = serviceProvider.CreateScope();
        
        foreach (var context in dbContexts)
        {
            (scope.ServiceProvider.GetService(context) as DbContext)?.Database.Migrate();   
        }
    }
}