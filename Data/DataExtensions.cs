using System;
using Microsoft.EntityFrameworkCore;

namespace Game_Store.Data;
// This is to make sure that the database is migrated as soon as the application starts.
public static class DataExtensions
{
    public static void MigrateDb(this WebApplication app){
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
        dbContext.Database.Migrate();
    }
}
