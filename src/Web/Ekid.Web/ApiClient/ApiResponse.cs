namespace Ekid.Web.ApiClient;

public abstract record ApiResponse(HttpResponseMessage? HttpResponse, bool Succeeded, ErrorResponses? Errors);

public record ApiResponse<T>(T? Value, HttpResponseMessage? HttpResponse, bool Succeeded, ErrorResponses? Errors) 
    : ApiResponse(HttpResponse, Succeeded, Errors);