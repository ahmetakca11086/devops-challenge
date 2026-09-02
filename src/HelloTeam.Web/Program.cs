var builder = WebApplication.CreateBuilder(args);

// REQUIRED PORT
builder.WebHost.UseUrls("http://0.0.0.0:52369");

var app = builder.Build();

var httpClient = new HttpClient();

app.MapGet("/", async () =>
{
    try
    {
        var response = await httpClient.GetFromJsonAsync<HelloResponse>(
            "http://webapi:11130/api/hello"
        );

        if (response == null || string.IsNullOrEmpty(response.Message))
        {
            return Results.Content("<h1>Empty response</h1>", "text/html");
        }

        return Results.Content($"<h1>{response.Message}</h1>", "text/html");
    }
    catch
    {
        return Results.Content("<h1>API not reachable</h1>", "text/html");
    }
});

app.Run();