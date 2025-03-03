using System;
using Game_Store.Data;
using Game_Store.Dtos;
using Game_Store.Entities;
using Game_Store.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Game_Store.Endpoints;

public static class GamesEndPoints
{
    const string GetGameEndpointName = "GetGame";
    public static RouteGroupBuilder MapGamesEndPoints(this WebApplication app)
    {
        var group = app.MapGroup("games").WithParameterValidation();
        // GET /games
        group.MapGet("/", (GameStoreContext dbContext) =>
        {
            return dbContext.Games
                .Include(game => game.Genre)
                .Select(game => game.ToGameSummaryDto())
                .AsNoTracking();
        });

        // GET /games/1
        group.MapGet("/{id}", (int id, GameStoreContext dbContext) =>
        {
            Game? game = dbContext.Games.Find(id);

            return game is null ? Results.NotFound() : Results.Ok(game.ToGameDetailsDto());
        })
        .WithName(GetGameEndpointName);

        // POST /games
        group.MapPost("/", (CreateGameDto newGame, GameStoreContext dbContext) =>
        {
            Game game = newGame.ToEntity();

            dbContext.Games.Add(game);
            dbContext.SaveChanges();
            
            return Results.CreatedAtRoute(
                GetGameEndpointName,
                new { id = game.Id }, 
                game.ToGameDetailsDto());
        });

        // PUT /games
        group.MapPut("/{id}", (int id, UpdateGameDto updatedGame, GameStoreContext dbContext) =>
        {
            var existingGame = dbContext.Games.Find(id);
            if (existingGame is null)
            {
                return Results.NotFound();
            }
            
            dbContext.Entry(existingGame)
                .CurrentValues
                .SetValues(updatedGame.ToEntity(id));

            dbContext.SaveChanges();

            return Results.NoContent();
        });

        // DELETE /games/1
        group.MapDelete("/{id}", (int id, GameStoreContext dbContext) =>
        {
            
            dbContext.Games
                .Where(game => game.Id == id)
                .ExecuteDelete();
            
            dbContext.SaveChanges();

            return Results.NoContent();
        });

        return group;
    }
}
