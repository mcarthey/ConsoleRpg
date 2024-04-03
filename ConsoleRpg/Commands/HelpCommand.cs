using System.Text.RegularExpressions;
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
            // Split the PascalCase command name into words
            var commandName = Regex.Replace(command.Value.GetType().Name, "(\\B[A-Z])", " $1");
            // Remove the last word "Command"
            commandName = commandName.Remove(commandName.LastIndexOf("Command"));
            CustomConsole.Info($"{command.Key} - {commandName}");
        }
    }
}
