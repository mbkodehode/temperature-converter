using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseStaticFiles();

app.MapGet("/", () => app.MapGet("/",context => {
    context.Response.Redirect("/index.html");
    return Task.CompletedTask;
}));

app.MapPost("/convert", (double temperature, TempUnits conversionType) => 
    TemperatureConverter.ConvertTemperature(temperature, conversionType)
);

app.Run();
