using Ekid.Infrastructure.AppInitialization;
using Ekid.Infrastructure.Auth;
using Ekid.Infrastructure.CallContext;
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
    private const string CorsPolicy = "cors";
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCors(cors =>
        {
            cors.AddPolicy(CorsPolicy, x =>
            {
                x.WithOrigins("http://localhost:5158")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddCommandQueryDispatcherWithHandlers();
        services.AddTransactionalHandlers();
        services.AddPermissionContainer();
        services.AddHostedService<AppInitializer>();
        services.AddAuth(configuration);
        services.AddCallContextComponents();
        services.AddSingleton<ExecutionPolicyMiddleware>();
    }

    public static void UseInfrastructure(this WebApplication app)
    {
        app.UseCors(CorsPolicy);
        app.Services.RegisterAllPermissions();
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseCallContext();
        app.UseMiddleware<ExecutionPolicyMiddleware>();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseModuleEndpoints();
        app.MapControllers();
    }
}