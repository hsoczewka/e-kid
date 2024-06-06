namespace Ekid.Infrastructure.Http;

public static class HttpContextExtensions
{
    internal static Guid? ParseGuid(this Microsoft.AspNetCore.Http.HttpContext httpContext, string header)
    {
        var headers = httpContext.Request.Headers[header];
        return headers.Count switch
        {
            1 => Guid.TryParse(headers.Single(), out var value)
                ? value
                : throw new Exception($"Unable to parse {header} header value."),
            > 1 => throw new Exception($"Multiple values of {header} header not supported."),
            _ => null
        };
    }
}