namespace Ekid.Web.ApiClient;

public record ErrorResponse(string Code, string Message);

public record ErrorResponses(ErrorResponse[] Errors);