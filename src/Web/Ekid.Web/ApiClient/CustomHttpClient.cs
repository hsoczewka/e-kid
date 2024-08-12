using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace Ekid.Web.ApiClient;

public sealed class CustomHttpClient
{
    private static readonly JsonSerializerOptions SerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };
    private readonly HttpClient _client;
    private readonly ILogger<CustomHttpClient> _logger;

    public CustomHttpClient(HttpClient client, ILogger<CustomHttpClient> logger)
    {
        _client = client;
        _logger = logger;
    }
    
    public Task<ApiResponse<T>> GetAsync<T>(string endpoint)
        => TrySendAsync<T>(new HttpRequestMessage(HttpMethod.Get, endpoint));
    
    public async Task<ApiResponse> PostAsync(string endpoint, object request)
        => await TrySendAsync<object>(new HttpRequestMessage(HttpMethod.Post, endpoint)
            { Content = CreateRequestContent(request) });
    
    public async Task<ApiResponse<T>> PostAsync<T>(string endpoint, object? request = null)
        => await TrySendAsync<T>(new HttpRequestMessage(HttpMethod.Post, endpoint)
            { Content = CreateRequestContent(request) });
    
    public async Task<ApiResponse> PutAsync(string endpoint, object request)
        => await TrySendAsync<object>(new HttpRequestMessage(HttpMethod.Put, endpoint)
            { Content = CreateRequestContent(request) });
    
    public async Task<ApiResponse> DeleteAsync(string endpoint)
        => await TrySendAsync<object>(new HttpRequestMessage(HttpMethod.Delete, endpoint));

    private static StringContent CreateRequestContent<T>(T request) 
        => new(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
    
    private async Task<ApiResponse<T>> TrySendAsync<T>(HttpRequestMessage request)
    {
        HttpResponseMessage? response = null;
        try
        {
            var requestId = Guid.NewGuid().ToString("N");
            _logger.LogInformation($"Sending HTTP request [ID: {requestId}]...");
            response = await _client.SendAsync(request);
            var isValid = response.IsSuccessStatusCode;
            var responseStatus = isValid ? "valid" : "invalid";
            _logger.LogInformation($"Received the {responseStatus} response [ID: {requestId}].");
            var responseContent = await response.Content.ReadAsStringAsync();
            if (!isValid)
            {
                var errors = string.IsNullOrWhiteSpace(responseContent)
                    ? default
                    : JsonSerializer.Deserialize<ErrorResponses>(responseContent, SerializerOptions);
                _logger.LogError(response.ToString());
                _logger.LogError(responseContent);
                return new ApiResponse<T>(default, response, false, errors);
            }

            var result = string.IsNullOrWhiteSpace(responseContent)
                ? default
                : JsonSerializer.Deserialize<T>(responseContent, SerializerOptions);

            return new ApiResponse<T>(result, response, true, null);

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new ApiResponse<T>(default, response, false, 
                new ErrorResponses(new []{new ErrorResponse(Code: "Error", Message: ex.Message)}));
        }
    }
}