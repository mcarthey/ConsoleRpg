using ConsoleRpg.Services;

namespace ConsoleRpg.Commands;

public class CheckInventoryCommand : ICommand
{
    private readonly PlayerService _playerService;

    public CheckInventoryCommand(PlayerService playerService)
    {
        _playerService = playerService;
    }

    public void Execute(string[] parameters)
    {
        _playerService.CheckInventory();
    }
}