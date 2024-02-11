using ConsoleRpg.Entities;
using ConsoleRpg.Services;
using Spectre.Console;

namespace ConsoleRpg;

public class Game
{
    private readonly QuestService _questService;
    private readonly CombatService _combatService;
    private readonly LocationService _locationService;
    private readonly MerchantService _merchantService;
    private readonly PlayerService _playerService;

    public Game(QuestService questService, CombatService combatService, LocationService locationService, MerchantService merchantService, PlayerService playerService)
    {
        _questService = questService;
        _combatService = combatService;
        _locationService = locationService;
        _merchantService = merchantService;
        _playerService = playerService;
    }

    public void Start()
    {
        var startingLocation = _locationService.GetStartingLocation();
        CustomConsole.Notice("\nWelcome to the Text RPG!\n");
        _locationService.DisplayLocationDetails(startingLocation);

        while (true)
        {
            CustomConsole.Info("\nWhat would you like to do?");
            CustomConsole.Prompt("1. Move to another location");
            CustomConsole.Prompt("2. Check inventory");
            CustomConsole.Prompt("3. Attack enemies");
            CustomConsole.Prompt("4. Visit the merchant");
            CustomConsole.Prompt("5. View current quests");
            CustomConsole.Prompt("6. Pick up quest");
            CustomConsole.Prompt("7. Quit\n");

            var choice = AnsiConsole.Ask<string>("");

            switch (choice)
            {
                case "1":
                    _locationService.MoveToLocation();
                    break;
                case "2":
                    _playerService.CheckInventory();
                    break;
                case "3":
                    var currentLocation = _locationService.GetCurrentLocation();
                    _combatService.AttackEnemies(currentLocation);
                    break;
                case "4":
                    _merchantService.DisplayVisitMessage();
                    break;
                case "5":
                    _playerService.ViewCurrentQuests();
                    break;
                case "6":
                    var quest = _locationService.GetQuestInCurrentLocation();
                    _questService.PickUpQuest(quest);
                    break;
                case "7":
                    SavePlayerAndQuit();
                    break;
                default:
                    InvalidChoice();
                    break;
            }
        }
    }

    private static void InvalidChoice()
    {
        CustomConsole.Warn("Invalid choice. Please try again.");
    }

    private void SavePlayerAndQuit()
    {
        CustomConsole.Notice("Saving player and quitting game...");
        _playerService.SavePlayer();
        Environment.Exit(0);
    }
}
