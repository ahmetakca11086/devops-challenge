using System.Net.Http.Json;

namespace HelloTeam.Web.Services;

public class HelloApiClient
{
    private readonly HttpClient _httpClient;

    public HelloApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<HelloResponse?> GetHelloAsync()
    {
        return await _httpClient.GetFromJsonAsync<HelloResponse>(
            "http://webapi:11130/api/hello"
        );
    }
}

// 👇 MUST be public (this fixes your error)
public class HelloResponse
{
    public string Message { get; set; } = string.Empty;
}