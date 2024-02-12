using ConsoleRpg.Entities;
using ConsoleRpg.Models.Characters;
using ConsoleRpg.Models.Items;
using ConsoleRpg.Models.Quests;
using Microsoft.EntityFrameworkCore;

namespace ConsoleRpg.Context;

public class RpgContext : DbContext
{
    public DbSet<Exit> Exits { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Merchant> Merchants { get; set; }
    public DbSet<LootTable> LootTables { get; set; }
    public DbSet<Npc> Npcs { get; set; }
    public DbSet<DialogueOption> DialogueOptions { get; set; }
    public DbSet<Command> Commands { get; set; }

    // Characters
    public DbSet<Character> Characters { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<Enemy> Enemies { get; set; }

    // Quests
    public DbSet<Quest> Quests { get; set; }
    public DbSet<KillEnemiesQuest> KillEnemiesQuests { get; set; }
    public DbSet<FindLocationQuest> FindLocationQuests { get; set; }
    public DbSet<FindItemQuest> FindItemQuests { get; set; }
    public DbSet<FindNpcQuest> FindNpcQuests { get; set; }

    // Items
    public DbSet<Item> Items { get; set; }
    public DbSet<Sword> Swords { get; set; }
    public DbSet<Shield> Shields { get; set; }
    public DbSet<Potion> Potions { get; set; }
    public DbSet<Gold> Golds { get; set; }
    public DbSet<GeneralItem> GeneralItems { get; set; }

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


        modelBuilder.Entity<Exit>()
            .HasOne(e => e.Location)
            .WithMany(l => l.Exits)
            .HasForeignKey(e => e.LocationId)
            .OnDelete(DeleteBehavior.Restrict); // This disables cascading deletes

        modelBuilder.Entity<Exit>()
            .HasOne(e => e.DestinationLocation)
            .WithMany()
            .HasForeignKey(e => e.DestinationLocationId)
            .OnDelete(DeleteBehavior.Restrict); // This disables cascading deletes

        modelBuilder.Entity<Enemy>()
            .HasOne(e => e.LootTable)
            .WithOne(l => l.Enemy)
            .HasForeignKey<LootTable>(l => l.EnemyId);

        base.OnModelCreating(modelBuilder);
    }
}
