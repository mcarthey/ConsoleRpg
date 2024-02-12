using ConsoleRpg.Services;

namespace ConsoleRpg.Commands;

public class ViewCurrentQuestsCommand : ICommand
{
    private readonly PlayerService _playerService;

    public ViewCurrentQuestsCommand(PlayerService playerService)
    {
        _playerService = playerService;
    }

    public void Execute(string[] parameters)
    {
        _playerService.ViewCurrentQuests();
    }
}