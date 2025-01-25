using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseStaticFiles();
// hello world endpoint
app.MapGet("/", async context => {
    context.Response.Redirect("/index.html");
    await Task.CompletedTask;
});
// Endpoint for temperature conversion
app.MapPost("/convert", ([FromForm] string temp, [FromForm] string fromUnits, [FromForm] string toUnits) => {
    if (!double.TryParse(temp, out double temperature))
    {
        return Results.BadRequest("temperature must be a number");
    } 
    var converter = new TemperatureConverter();
    return Results.Ok(new { convertedTemperature = converter.ConvertTemperature(temperature, fromUnits, toUnits) });
}).DisableAntiforgery();

app.Run();