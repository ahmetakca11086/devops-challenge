using System.Net.Http.Json;
using HelloTeam.Web.Models;

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
            "/api/hello");
    }
}

