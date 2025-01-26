using Microsoft.AspNetCore.Mvc;
using oppgave3; // Import the namespace where the Team and Player class is defined

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

Team? team = null; // Static variable to store the Team instance

app.MapGet("/", () => "Hello World!");

// Endpoint for creating a team
app.MapPost("/addteam", ([FromForm] string teamName) => {
    team = new Team(teamName);
    Team.count++;
    return Results.Ok(team);
}).DisableAntiforgery();

// Endpoint for showing team name
app.MapGet("/showteam", () => {
    if (team == null)
    {
        return Results.NotFound("Team not found");
    }
    return Results.Ok(team);
}).DisableAntiforgery();

// Endpoint for deleting team
app.MapDelete("/deleteteam", () => {
    if (team == null)
    {
        return Results.NotFound("Team not found");
    }
    team = null;
    Team.count--;
    return Results.Ok("Team deleted");
}).DisableAntiforgery();

// Endpoint for adding player to team
app.MapPost("/addplayer", ([FromForm] string name, [FromForm] int age, [FromForm] string position, [FromForm] int rank) => {
    if (team == null)
    {
        return Results.BadRequest("Team not created");
    }
    var player = new Player(name, age, position, rank);
    team.AddPlayer(player);
    return Results.Ok(player);
}).DisableAntiforgery();

// Endpoint for updating player
app.MapPatch("/updateplayer", ([FromForm] string name, [FromForm] int age, [FromForm] string position, [FromForm] int rank) => {
    if (team == null)
    {
        return Results.BadRequest("Team not created");
    }
    var player = new Player(name, age, position, rank);
    team.UpdatePlayer(player);
    return Results.Ok(player);
}).DisableAntiforgery();

// Endpoint for reading all players
app.MapGet("/players", () => {
    if (team == null)
    {
        return Results.BadRequest("Team not created");
    }
    return Results.Ok(team.GetPlayers());
}).DisableAntiforgery();

// Endpoint for deleting a player
app.MapDelete("/deleteplayer", ([FromForm] string name) => {
    if (team == null)
    {
        return Results.BadRequest("Team not created");
    }
    var player = team.GetPlayer(name);
    if (player == null)
    {
        return Results.NotFound("Player not found");
    }
    team.RemovePlayer(player);
    return Results.Ok("Player removed");
}).DisableAntiforgery();

// Endpoint for finding players by rank
app.MapGet("/players/rank/{rank}", ([FromRoute] int rank) => {
    if (team == null)
    {
        return Results.BadRequest("Team not created");
    }
    var players = team.GetPlayersByRank(rank);
    return Results.Ok(players);
}).DisableAntiforgery();

// Endpoint for calculating team statistics
app.MapGet("/team/stats", () => {
    if (team == null)
    {
        return Results.BadRequest("Team not created");
    }
    var stats = team.CalculateStatistics();
    return Results.Ok(stats);
}).DisableAntiforgery();

app.Run();
