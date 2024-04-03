using ConsoleRpg.Entities;
using ConsoleRpg.Models.Characters;
using ConsoleRpg.Models.Items;
using ConsoleRpg.Models.Items.Effects;
using ConsoleRpg.Models.Items.Types;
using ConsoleRpg.Models.Npcs;
using ConsoleRpg.Models.Npcs.Types;
using ConsoleRpg.Models.Quests;
using Microsoft.EntityFrameworkCore;

namespace ConsoleRpg.Context;

public class RpgContext : DbContext
{
    // Character related entities
    public DbSet<Character> Characters { get; set; } // Includes Player and Enemy

    // Item related entities
    public DbSet<Item> Items { get; set; } // Includes GeneralItem, Gold, Potion, Shield, Sword, BreakableItem, DrinkableItem, and any classes that inherit from LootableItem

    // NPC related entities
    public DbSet<Npc> Npcs { get; set; } // Includes Merchant, InformativeNpc, and InteractiveNpc

    // Quest related entities
    public DbSet<Quest> Quests { get; set; } // Includes FindItemQuest, FindLocationQuest, FindNpcQuest, and KillEnemiesQuest

    // Effect related entities
    public DbSet<Effect> Effects { get; set; } // Includes BoostAttributeEffect, DamageEffect, and HealEffect

    // Other entities
    public DbSet<Location> Locations { get; set; }
    public DbSet<DialogueOption> DialogueOptions { get; set; }
    public DbSet<Command> Commands { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Inventory> Inventories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseLazyLoadingProxies()
            .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ConsoleRpgDb;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>()
            .HasDiscriminator<string>("ItemType")
            .HasValue<GeneralItem>("GeneralItem")
            .HasValue<Gold>("Gold")
            .HasValue<Potion>("Potion")
            .HasValue<Shield>("Shield")
            .HasValue<Sword>("Sword");

        modelBuilder.Entity<Effect>()
            .HasDiscriminator<string>("EffectType")
            .HasValue<HealEffect>("Heal")
            .HasValue<DamageEffect>("Damage")
            .HasValue<BoostAttributeEffect>("BoostAttribute");

        modelBuilder.Entity<Npc>()
            .HasDiscriminator<string>("NpcType")
            .HasValue<Merchant>("Merchant")
            .HasValue<InformativeNpc>("Informative")
            .HasValue<InteractiveNpc>("Interactive");

        modelBuilder.Entity<Quest>()
            .HasDiscriminator<string>("QuestType")
            .HasValue<FindItemQuest>("FindItem")
            .HasValue<FindLocationQuest>("FindLocation")
            .HasValue<FindNpcQuest>("FindNpc")
            .HasValue<KillEnemiesQuest>("KillEnemies");

        modelBuilder.Entity<Character>()
            .HasDiscriminator<string>("CharacterType")
            .HasValue<Player>("Player")
            .HasValue<Enemy>("Enemy");
    }
}