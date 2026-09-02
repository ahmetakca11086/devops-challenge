using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;

namespace HelloTeam.Api.Tests;

public class HelloApiTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public HelloApiTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task HelloEndpoint_ReturnsExpectedMessage()
    {
        var response = await _client.GetAsync("/api/hello");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var body = await response.Content.ReadFromJsonAsync<HelloResponse>();

        Assert.NotNull(body);
        Assert.Equal("Hello Ziraat Team from aakca!", body!.Message);
    }

    [Fact]
    public async Task LiveEndpoint_ReturnsAlive()
    {
        var response = await _client.GetAsync("/health/live");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task ReadyEndpoint_ReturnsReady()
    {
        var response = await _client.GetAsync("/health/ready");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    private sealed class HelloResponse
    {
        public string Message { get; set; } = string.Empty;
    }
}

