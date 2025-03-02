using Game_Store.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

const string GetGameEndpointName = "GetGame";

List<GameDto> games = new List<GameDto>
{
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
};

// GET /games
app.MapGet("/games", ()=>{
    return games;
});

// GET /games/1
app.MapGet("games/{id}", (int id)=>{
    GameDto? game =  games.Find(games => games.Id == id);

    return game is null ? Results.NotFound() : Results.Ok(game);
})
.WithName(GetGameEndpointName);

// POST /games
app.MapPost("/games", (CreateGameDto newGame)=>{
    // convert CreateGameDto to GameDto to store it
    GameDto game = new (
        games.Count + 1,
        newGame.Name,
        newGame.Genre,
        newGame.Price,
        newGame.ReleaseDate
    );
    games.Add(game);

    return Results.CreatedAtRoute(GetGameEndpointName, new {id = game.Id}, game);
});

// PUT /games
app.MapPut("games/{id}", (int id, UpdateGameDto updatedGame)=>{
    var index = games.FindIndex(game => game.Id == id);
    if (index == -1){
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
app.MapDelete("games/{id}", (int id)=>{
    games.RemoveAll(game => game.Id == id);

    return Results.NoContent();
});


app.Run();
