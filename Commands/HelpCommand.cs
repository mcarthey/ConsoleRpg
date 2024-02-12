using ConsoleRpg.Utils;

namespace ConsoleRpg.Commands;

public class HelpCommand : ICommand
{
    private readonly CommandRegistry _commandRegistry;

    public HelpCommand(CommandRegistry commandRegistry)
    {
        _commandRegistry = commandRegistry;
    }

    public void Execute(string[] parameters)
    {
        var commands = _commandRegistry.GetCommands();

        foreach (var command in commands)
        {
            CustomConsole.Info($"{command.Key} - {command.Value.GetType().Name}");
        }
    }
}
