using Ekid.Infrastructure.AppInitialization;
using Ekid.Infrastructure.Auth;
using Ekid.Infrastructure.ExecutionPolicy;
using Ekid.Infrastructure.Messaging;
using Ekid.Infrastructure.ModuleContext;
using Ekid.Infrastructure.Security;
using Ekid.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Ekid.Infrastructure;

public static class Bootstrap
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddCommandQueryDispatcherWithHandlers();
        services.AddTransactionalHandlers();
        services.AddPermissionContainer();
        services.AddHostedService<AppInitializer>();
        services.AddAuth(configuration);
        services.AddSingleton<ExecutionPolicyMiddleware>();
    }

    public static void UseInfrastructure(this WebApplication app)
    {
        app.Services.RegisterAllPermissions();
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseMiddleware<ExecutionPolicyMiddleware>();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseEndpoints(endpoints => endpoints.UseModuleEndpoints());
        app.MapControllers();
    }
}