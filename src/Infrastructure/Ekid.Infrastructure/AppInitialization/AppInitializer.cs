using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Ekid.Infrastructure.AppInitialization;

public class AppInitializer : IHostedService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<AppInitializer> _logger;

    public AppInitializer(IServiceProvider serviceProvider, ILogger<AppInitializer> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        var dbContexts = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes())
            .Where(type => typeof(DbContext).IsAssignableFrom(type))
            .Where(type => !type.IsAbstract)
            .Where(type => type != typeof(DbContext))
            .ToList();

        using var scope = _serviceProvider.CreateScope();
        
        foreach (var context in dbContexts)
        {
            var dbContext = scope.ServiceProvider.GetService(context) as DbContext;
            if (dbContext is null)
            {
                continue;
            }
            _logger.LogInformation($"Running migration for DB context {context}");
            await dbContext.Database.MigrateAsync(cancellationToken);  
        }
        
        var initializers = scope.ServiceProvider.GetServices<IComponentInitializer>();
        foreach (var initializer in initializers)
        {
            try
            {
                _logger.LogInformation($"Component initializer running for: {initializer.GetType().Name}...");
                await initializer.InitializeAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}