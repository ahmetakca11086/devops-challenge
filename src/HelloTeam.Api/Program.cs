var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/api/hello", () =>
{
    return Results.Ok(new
    {
        message = "Hello Ziraat Team from aakca"
    });
});

app.MapGet("/health/live", () =>
{
    return Results.Ok(new
    {
        status = "alive"
    });
});

app.MapGet("/health/ready", () =>
{
    return Results.Ok(new
    {
        status = "ready"
    });
});

app.Run();

public partial class Program { }
