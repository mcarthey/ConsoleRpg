namespace ConsoleRpg.Commands;

public class SavePlayerAndQuitCommand : ICommand
{
    private readonly Game _game;

    public SavePlayerAndQuitCommand(Game game)
    {
        _game = game;
    }

    public void Execute(string[] parameters)
    {
        _game.SavePlayerAndQuit();
    }
}