var builder = WebApplication.CreateBuilder(args);

// REQUIRED PORT
builder.WebHost.UseUrls("http://0.0.0.0:52369");

var app = builder.Build();

var httpClient = new HttpClient();

app.MapGet("/", async () =>
{
    try
    {
    var json = await httpClient.GetFromJsonAsync<dynamic>("http://webapi:11130/api/hello");
return Results.Content($"<h1>{json.message}</h1>", "text/html");
    }
    catch
    {
        return Results.Content("<h1>API not reachable</h1>", "text/html");
    }
});

app.Run();