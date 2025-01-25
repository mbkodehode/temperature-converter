using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// hello world endpoint
app.MapGet("/", () => "Hello World!");

// Endpoint for temperature conversion
app.MapPost("/convert", ([FromForm] double temp, [FromForm] string fromUnits, [FromForm] string toUnits) => {
    if (double.IsNaN(temp))
    {
        return Results.BadRequest("temperature must be a number");
    } 
    var converter = new TemperatureConverter();
    return Results.Ok(new { convertedTemperature = converter.ConvertTemperature(temp, fromUnits, toUnits) });
}).DisableAntiforgery();

app.Run();