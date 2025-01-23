using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseStaticFiles();

app.MapGet("/", context => {
    context.Response.Redirect("/index.html");
    return Task.CompletedTask;
});

app.MapPost("/convert", ([FromForm] double temperature, [FromForm] TempUnits conversionType) => {
    var converter = new TemperatureConverter();
    return Results.Json(new { convertedTemperature = converter.ConvertTemperature(temperature, conversionType) });
});
app.Run();
