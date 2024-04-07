using Microsoft.Extensions.Logging;

namespace ConsoleRpg.Utils;

public class CommandParser
{
    private readonly CommandRegistry _commandRegistry;
    private readonly ILogger<CommandParser> _logger;

    public CommandParser(CommandRegistry commandRegistry, ILogger<CommandParser> logger)
    {
        _commandRegistry = commandRegistry;
        _logger = logger;
    }

    public void ParseCommand(string input)
    {
        _logger.LogInformation("Parsing command: {input}", input);

        if (string.IsNullOrWhiteSpace(input))
        {
            CustomConsole.Warn("No command provided. Please try again.");
            return;
        }

        var commandName = input.Split(' ')[0].ToLower();
        var commandParameters = input.Contains(' ') ? input.Substring(input.IndexOf(' ') + 1) : ""; // Get everything after the first space

        var commands = _commandRegistry.GetCommands();

        if (commands.TryGetValue(commandName, out var command))
        {
            try
            {
                command.Execute(new string[] { commandParameters });
            }
            catch (Exception ex)
            {
                CustomConsole.Warn(ex.Message);
            }
        }
        else
        {
            CustomConsole.Warn("Invalid command. Please try again.");
        }
    }

}
