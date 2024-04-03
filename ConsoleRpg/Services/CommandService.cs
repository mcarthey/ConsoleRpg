using ConsoleRpg.Utils;
using Microsoft.Extensions.Logging;

namespace ConsoleRpg.Services;

public class CommandService : ICommandService
{
    private readonly CommandParser _commandParser;
    private readonly ILogger<ICommandService> _logger;

    public CommandService(CommandParser commandParser, ILogger<ICommandService> logger)
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
