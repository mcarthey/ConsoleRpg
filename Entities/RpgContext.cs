﻿using Microsoft.EntityFrameworkCore;

namespace ConsoleRpg.Entities;

public class RpgContext : DbContext
{
    public DbSet<Player> Players { get; set; }
    public DbSet<Enemy> Enemies { get; set; }
    public DbSet<Quest> Quests { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Merchant> Merchants { get; set; }
    public DbSet<Location> Locations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseLazyLoadingProxies()
            .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ConsoleRpgDb;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Player>()
            .HasMany(p => p.ActiveQuests)
            .WithMany(q => q.Players)
            .UsingEntity<Dictionary<string, object>>(
                "PlayerQuests",
                j => j
                    .HasOne<Quest>()
                    .WithMany()
                    .HasForeignKey("QuestId"),
                j => j
                    .HasOne<Player>()
                    .WithMany()
                    .HasForeignKey("PlayerId")
            );
    }
}