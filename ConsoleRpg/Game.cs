using ConsoleRpg.Services;
using ConsoleRpg.Utils;
using Spectre.Console;

namespace ConsoleRpg;

public class Game
{
    private readonly LocationService _locationService;
    private readonly PlayerService _playerService;
    private readonly CommandService _commandService;
    private readonly SessionService _sessionService;

    public Game(LocationService locationService, PlayerService playerService, CommandService commandService, SessionService sessionService)
    {
        _locationService = locationService;
        _playerService = playerService;
        _commandService = commandService;
        _sessionService = sessionService;
    }

    public void Start()
    {
        CustomConsole.Notice("\nWelcome to the Text RPG!\n");

        var username = AnsiConsole.Ask<string>("Please enter your username:");
        _sessionService.Login(username);

        if (_sessionService.CurrentUser == null)
        {
            CustomConsole.Warn("Invalid username. Please try again.");
            return;
        }

        var startingLocation = _locationService.GetStartingLocation();
        CustomConsole.Notice("\nWelcome to the Text RPG!\n");
        _locationService.DisplayLocationDetails(startingLocation);

        while (true)
        {
            CustomConsole.Prompt("\nWhat would you like to do?");

            var input = AnsiConsole.Ask<string>("");

            _commandService.ExecuteCommand(input);
        }
    }

    private static void InvalidChoice()
    {
        CustomConsole.Warn("Invalid choice. Please try again.");
    }

    public void SavePlayerAndQuit()
    {
        CustomConsole.Notice("Saving player and quitting game...");

        Environment.Exit(0);
    }
}
