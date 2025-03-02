using System;
using Game_Store.Dtos;

namespace Game_Store.Endpoints;

public static class GamesEndPoints
{
    const string GetGameEndpointName = "GetGame";

    private static readonly List<GameDto> games =
    [
        new(1, "Street Fighter II", "Fighting", 19.99M, new DateOnly(1992, 7, 15)),
    new(2, "Super Mario Bros.", "Platformer", 14.99M, new DateOnly(1985, 9, 13)),
    new(3, "The Legend of Zelda", "Action-Adventure", 24.99M, new DateOnly(1986, 2, 21)),
    new(4, "Final Fantasy VII", "RPG", 29.99M, new DateOnly(1997, 1, 31)),
    new(5, "Doom", "FPS", 9.99M, new DateOnly(1993, 12, 10)),
    new(6, "Half-Life 2", "FPS", 39.99M, new DateOnly(2004, 11, 16)),
    new(7, "Red Dead Redemption 2", "Action-Adventure", 59.99M, new DateOnly(2018, 10, 26)),
    new(8, "God of War", "Action", 49.99M, new DateOnly(2018, 4, 20)),
    new(9, "The Witcher 3: Wild Hunt", "RPG", 39.99M, new DateOnly(2015, 5, 19)),
    new(10, "Minecraft", "Sandbox", 26.95M, new DateOnly(2011, 11, 18))
    ];

    public static RouteGroupBuilder MapGamesEndPoints(this WebApplication app)
    {
        var group = app.MapGroup("games").WithParameterValidation();
        // GET /games
        group.MapGet("/", () =>
        {
            return games;
        });

        // GET /games/1
        group.MapGet("/{id}", (int id) =>
        {
            GameDto? game = games.Find(games => games.Id == id);

            return game is null ? Results.NotFound() : Results.Ok(game);
        })
        .WithName(GetGameEndpointName);

        // POST /games
        group.MapPost("/", (CreateGameDto newGame) =>
        {
            // convert CreateGameDto to GameDto to store it
            GameDto game = new(
                games.Count + 1,
                newGame.Name,
                newGame.Genre,
                newGame.Price,
                newGame.ReleaseDate
            );
            games.Add(game);

            return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);
        });

        // PUT /games
        group.MapPut("/{id}", (int id, UpdateGameDto updatedGame) =>
        {
            var index = games.FindIndex(game => game.Id == id);
            if (index == -1)
            {
                return Results.NotFound();
            }
            games[index] = new GameDto(
                id,
                updatedGame.Name,
                updatedGame.Genre,
                updatedGame.Price,
                updatedGame.ReleaseDate
            );

            return Results.NoContent();
        });

        // DELETE /games/1
        group.MapDelete("/{id}", (int id) =>
        {
            games.RemoveAll(game => game.Id == id);

            return Results.NoContent();
        });

        return group;
    }
}
