using ConsoleRpg.Commands;
using ConsoleRpg.Context;
using ConsoleRpg.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ConsoleRpg.Utils;

public class CommandRegistry
{
    private readonly RpgContext _context;
    private Dictionary<string, ICommand> _commands;
    private readonly ILogger<CommandRegistry> _logger;
    private readonly IServiceProvider _serviceProvider;

    public CommandRegistry(RpgContext context, ILogger<CommandRegistry> logger, IServiceProvider serviceProvider)
    {
        _context = context;
        _commands = new Dictionary<string, ICommand>();
        _logger = logger;
        _serviceProvider = serviceProvider;
    }

    public Dictionary<string, ICommand> GetCommands()
    {
        if (_commands.Any())
        {
            return _commands;
        }

        var commandEntities = _context.Commands.ToList();

        foreach (var commandEntity in commandEntities)
        {
            var command = GetCommand(commandEntity);
            if (command != null)
            {
                _commands.Add(commandEntity.Name, command);
            }
        }

        return _commands;
    }

    private ICommand GetCommand(Command command)
    {
        _logger.LogInformation("Getting command: {command}", command.Name);

        // Use reflection to get the class type
        var classType = Type.GetType($"ConsoleRpg.Commands.{command.ClassName}");
        if (classType == null)
        {
            _logger.LogWarning("Could not find command class: {className}", command.ClassName);
            return new DefaultCommand();
        }

        // Use dependency injection to create an instance of the command class
        var commandInstance = ActivatorUtilities.CreateInstance(_serviceProvider, classType) as ICommand;
        return commandInstance ?? new DefaultCommand();
    }


}

public class DefaultCommand : ICommand
{
    public void Execute(string[] parameters)
    {
        // Default behavior when no command is found
    }
}
