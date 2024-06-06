using Microsoft.AspNetCore.Http;

namespace Ekid.Infrastructure.ExecutionPolicy;

public class ExecutionPolicyMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var endpoint = context.GetEndpoint();
        if (endpoint != null)
        {
            var requiredRoles = endpoint.Metadata
                .Where(meta => meta is RequireAdminAttribute || meta is RequireEmployeeAttribute || meta is RequireSystemAttribute)
                .Select(meta => meta.GetType().Name)
                .ToList();

            if (requiredRoles.Count != 0 && !IsUserAuthorized(context, requiredRoles))
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("You do not have permission to perform this action.");
                return;
            }
        }

        await next(context);
    }
    
    private bool IsUserAuthorized(HttpContext context, List<string> requiredRoles)
    {
        var userRoles = context.User.Claims.Where(c => c.Type == "role").Select(c => c.Value);

        foreach (var role in requiredRoles)
        {
            switch (role)
            {
                case nameof(RequireAdminAttribute) when userRoles.Contains("Administrator"):
                case nameof(RequireEmployeeAttribute) when userRoles.Contains("Employee"):
                case nameof(RequireSystemAttribute) when userRoles.Contains("System"):
                    return true;
            }
        }

        return false;
    }
}