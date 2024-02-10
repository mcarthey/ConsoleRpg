using ConsoleRpg.Entities;
using ConsoleRpg.Services;

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
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nWelcome to the Text RPG!\n");
        Console.ResetColor();
        _locationService.DisplayLocationDetails(startingLocation);

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nWhat would you like to do?");
            Console.WriteLine("1. Move to another location");
            Console.WriteLine("2. Check inventory");
            Console.WriteLine("3. Attack enemies");
            Console.WriteLine("4. Visit the merchant");
            Console.WriteLine("5. View current quests");
            Console.WriteLine("6. Pick up quest");
            Console.WriteLine("7. Quit\n");
            Console.ResetColor();

            var choice = Console.ReadLine();
            if (choice == null)
            {
                throw new Exception("Failed to read choice.");
            }

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
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid choice. Please try again.");
        Console.ResetColor();
    }

    private void SavePlayerAndQuit()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Saving player and quitting game...");
        Console.ResetColor();
        _playerService.SavePlayer();
        Environment.Exit(0);
    }
}
