var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => app.MapGet("/",context => {
    // Greeting("Devrim");
    context.Response.Redirect("/index.html");
    return Task.CompletedTask;
}));
app.Run();
