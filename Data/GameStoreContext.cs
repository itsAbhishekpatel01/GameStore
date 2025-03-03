using System;
using Game_Store.Entities;
using Microsoft.EntityFrameworkCore;

namespace Game_Store.Data;

public class GameStoreContext(DbContextOptions<GameStoreContext> options) : DbContext(options)
{
    public DbSet<Game> Games => Set<Game>();

    public DbSet<Genre> Genre => Set<Genre>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>().HasData(
        new { Id = 1, Name = "Fighting" },
        new { Id = 2, Name = "Action" },
        new { Id = 3, Name = "Adventure" },
        new { Id = 4, Name = "RPG" },
        new { Id = 5, Name = "Strategy" }
        );

    }
}
