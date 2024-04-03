using ConsoleRpg.Entities;
using ConsoleRpg.Models.Characters;

public interface ICombatService
{
    void AttackCharacters(Location currentLocation);
    void Fight(Enemy enemy);
}