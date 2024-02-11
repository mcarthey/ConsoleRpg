using ConsoleRpg.Context;
using ConsoleRpg.Entities;
using ConsoleRpg.Models.Characters;
using ConsoleRpg.Models.Items;
using Microsoft.EntityFrameworkCore;
using Spectre.Console;

namespace ConsoleRpg.Services;

public class CombatService
{
    private const int DamageRandomness = 10;
    private readonly PlayerService _playerService;
    private readonly Random _random = new();
    private readonly LocationService _locationService;
    private readonly RpgContext _context;
    private readonly object _lock = new object();

    public CombatService(PlayerService playerService, LocationService locationService, RpgContext context) // Update this line
    {
        _playerService = playerService;
        _locationService = locationService;
        _context = context;
    }

    public Item GetRandomItemFromLootTable(LootTable lootTable)
    {
        Random random = new Random();
        var allItems = lootTable.Items.ToList();
        int index = random.Next(allItems.Count);
        return allItems.ElementAt(index);
    }

    public void AttackEnemies(Location currentLocation)
    {
        var player = _playerService.GetPlayer();
        CustomConsole.Info($"Attacking enemies at {currentLocation.Name}...");
        lock (_lock)
        {
            var enemies = new List<Enemy>(currentLocation.Enemies);
            foreach (var enemy in enemies)
            {
                Combat(player, enemy);
            }
        }
    }


    private void RespawnEnemy(Enemy enemy)
    {
        var newLocation = _locationService.GetRandomLocation();
        enemy.Respawn(newLocation);
    }

    public void Combat(Player player, Enemy enemy)
    {
        while (player.Health > 0 && enemy.Health > 0)
        {
            Attack(player, enemy);
            if (enemy.Health <= 0)
            {
                CustomConsole.Highlight("Enemy defeated!");
                player.GainExperience(enemy.Experience);
                UpdateQuestProgress(enemy);
                DropLoot(player, enemy);
                RespawnEnemy(enemy);
                break;
            }

            Attack(enemy, player);
            if (player.Health <= 0)
            {
                CustomConsole.Warn("Player defeated!");
                _playerService.ResetPlayer(player);
                break;
            }
        }
    }
    public void DropLoot(Player player, Enemy enemy)
    {
        var loot = GetRandomItemFromLootTable(enemy.LootTable);
        CustomConsole.Notice($"Enemy dropped {loot.Name}!");
        if (loot is Sword)
        {
            player.Swords.Add((Sword)loot);
        }
        else if (loot is Shield)
        {
            player.Shields.Add((Shield)loot);
        }
        else if (loot is Potion)
        {
            player.Potions.Add((Potion)loot);
        }
        else if (loot is Gold)
        {
            player.Golds.Add((Gold)loot);
        }
        else
        {
            player.Inventory.Add(loot);
        }
        _context.SaveChanges();
    }




    private void UpdateQuestProgress(Enemy enemy)
    {
        if (enemy.Quest != null)
        {
            enemy.Quest.KillCountProgress++;
            if (enemy.Quest.KillCountProgress >= enemy.Quest.KillCount)
            {
                enemy.Quest.IsCompleted = true;
            }
        }
    }

    private void Attack(Character attacker, Character defender)
    {
        var damage = CalculateDamage(attacker.Attack);
        defender.Health -= damage;
        CustomConsole.Highlight($"{attacker.Name} attacks and deals {damage} damage to {defender.Name}.");
        CustomConsole.Highlight($"{defender.Name} has {defender.Health} health remaining.");
    }

    private int CalculateDamage(int attackPower)
    {
        var damage = attackPower + _random.Next(1, DamageRandomness);
        return damage;
    }
}