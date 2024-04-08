using ConsoleRpg.Entities;
using ConsoleRpg.Models.Characters;

namespace ConsoleRpg.Services;

public interface ICombatService
{
    void AttackCharacters(Location currentLocation);
    void Fight(Enemy enemy);
}