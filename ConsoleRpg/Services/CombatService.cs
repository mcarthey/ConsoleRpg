using ConsoleRpg.Context;
using ConsoleRpg.Entities;
using ConsoleRpg.Models.Characters;
using ConsoleRpg.Models.Items;
using ConsoleRpg.Utils;

namespace ConsoleRpg.Services;

public class CombatService : ICombatService
{
    private readonly ISessionService _sessionService;

    private const int DamageRandomness = 10;
    private readonly Random _random = new();
    private readonly Player _player;

    public CombatService(ISessionService sessionService)
    {
        _sessionService = sessionService;
        _player = _sessionService.CurrentPlayer;
    }

    public void AttackCharacters(Location currentLocation)
    {
        CustomConsole.Info($"Attacking characters at {currentLocation.Name}...");
        var characters = new List<Character>(currentLocation.Characters);
        foreach (var character in characters)
        {
            if (character is Enemy enemy)
            {
                Fight(enemy);
            }
        }
    }

    public void Fight(Enemy enemy)
    {
        while (_player.Health > 0 && enemy.Health > 0)
        {
            Attack(_player, enemy);
            if (enemy.Health <= 0)
            {
                CustomConsole.Highlight("Enemy defeated!");
                _player.Experience += enemy.Experience;
                UpdateQuestProgress(enemy);
                break;
            }

            Attack(enemy, _player);
            if (_player.Health <= 0)
            {
                CustomConsole.Warn("Player defeated!");
                break;
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
        CustomConsole.Highlight($"{attacker.Name} attacks and deals {damage} damage to {defender.Name}.");
        CustomConsole.Highlight($"{defender.Name} has {defender.Health} health remaining.");
    }

    private int CalculateDamage(int attackPower)
    {
        var damage = attackPower + _random.Next(1, DamageRandomness);
        return damage;
    }
}