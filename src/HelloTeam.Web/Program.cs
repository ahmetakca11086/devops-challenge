var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://0.0.0.0:52369");

var app = builder.Build();

var httpClient = new HttpClient();

app.MapGet("/", async () =>
{
    try
    {
        var json = await httpClient.GetFromJsonAsync<HelloResponse>(
            "http://webapi:11130/api/hello"
        );

        if (json == null)
            return Results.Content("<h1>No response</h1>", "text/html");

        return Results.Content($"<h1>{json.Message}</h1>", "text/html");
    }
    catch
    {
        return Results.Content("<h1>API not reachable</h1>", "text/html");
    }
});

app.Run();

class HelloResponse
{
    public string Message { get; set; } = string.Empty;
}