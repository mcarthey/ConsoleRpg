using ConsoleRpg.Entities;
using ConsoleRpg.Models;
using ConsoleRpg.Services;

public class CombatService
{
    private const int DamageRandomness = 10;
    private readonly PlayerService _playerService;
    private readonly Random _random = new();
    private readonly LocationService _locationService;
    private readonly object _lock = new object();

    public CombatService(PlayerService playerService, LocationService locationService)
    {
        _playerService = playerService;
        _locationService = locationService;
    }


    public void AttackEnemies(Location currentLocation)
    {
        var player = _playerService.GetPlayer();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Attacking enemies...");
        Console.ResetColor();
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
                Console.WriteLine("Enemy defeated!");
                player.GainExperience(enemy.Experience);
                UpdateQuestProgress(enemy);
                DropLoot(player, enemy);
                RespawnEnemy(enemy);
                break;
            }

            Attack(enemy, player);
            if (player.Health <= 0)
            {
                Console.WriteLine("Player defeated!");
                _playerService.ResetPlayer(player);
                break;
            }
        }
    }
    private void DropLoot(Player player, Enemy enemy)
    {
        if (enemy.LootTable != null)
        {
            var item = enemy.LootTable.GetRandomItem();
            if (item != null)
            {
                player.Inventory.Add(item);
                Console.WriteLine($"You found a {item.Name}!");
                Console.WriteLine($"You received {item.Name} from {enemy.Name}!"); 
            }
        }
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
        Console.WriteLine($"{attacker.Name} attacks and deals {damage} damage to {defender.Name}.");
        Console.WriteLine($"{defender.Name} has {defender.Health} health remaining.");
    }

    private int CalculateDamage(int attackPower)
    {
        var damage = attackPower + _random.Next(1, DamageRandomness);
        return damage;
    }
}
