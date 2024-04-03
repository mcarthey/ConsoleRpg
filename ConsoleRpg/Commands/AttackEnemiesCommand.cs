using ConsoleRpg.Entities;
using ConsoleRpg.Services;

namespace ConsoleRpg.Commands;

public class AttackEnemiesCommand : ICommand
{
    private readonly ICombatService? _combatService;
    private readonly Location? _location;

    public AttackEnemiesCommand(Location location)
    {
        _location = location;
    }

    public AttackEnemiesCommand(ICombatService combatService)
    {
        _combatService = combatService;
    }

    public void Execute(string[] parameters)
    {
        if (_combatService == null || _location == null)
        {
            throw new InvalidOperationException("CombatService and Location must not be null.");
        }

        _combatService.AttackCharacters(_location);
    }
}