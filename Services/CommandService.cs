using ConsoleRpg.Utils;
using Microsoft.Extensions.Logging;

namespace ConsoleRpg.Services;

public class CommandService
{
    private readonly CommandParser _commandParser;
    private readonly ILogger<CommandService> _logger;

    public CommandService(CommandParser commandParser, ILogger<CommandService> logger)
    {
        _commandParser = commandParser;
        _logger = logger;
    }

    public void ExecuteCommand(string input)
    {
        _logger.LogInformation("Executing command: {input}", input);
        _commandParser.ParseCommand(input);
    }
}
