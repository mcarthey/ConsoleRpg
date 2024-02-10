using ConsoleRpg.Entities;

public class CombatService
{
    private const int DamageRandomness = 10;
    private Random _random = new Random();

    public void Combat(Player player, Enemy enemy)
    {
        while (player.Health > 0 && enemy.Health > 0)
        {
            Attack(player, enemy);
            if (enemy.Health <= 0)
            {
                Console.WriteLine("Enemy defeated!");
                player.GainExperience(enemy.Experience);
                break;
            }

            Attack(enemy, player);
            if (player.Health <= 0)
            {
                Console.WriteLine("Player defeated!");
                break;
            }
        }
    }

    private void Attack(Character attacker, Character defender)
    {
        int damage = CalculateDamage(attacker.Attack);
        defender.Health -= damage;
        Console.WriteLine($"{attacker.Name} attacks and deals {damage} damage to {defender.Name}.");
        Console.WriteLine($"{defender.Name} has {defender.Health} health remaining.");
    }

    private int CalculateDamage(int attackPower)
    {
        int damage = attackPower + _random.Next(1, DamageRandomness);
        return damage;
    }
}
