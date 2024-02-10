using ConsoleRpg.Entities;
using ConsoleRpg.Services;
using Microsoft.EntityFrameworkCore;

namespace ConsoleRpg;

public class Game
{
    private RpgContext _context;
    private PlayerService _playerService;
    private LocationService _locationService;
    private MerchantService _merchantService;
    private CombatService _combatService;
    private readonly QuestService _questService;

    public Game()
    {
        _context = new RpgContext();
        _playerService = new PlayerService(_context);
        _locationService = new LocationService(_context);
        _merchantService = new MerchantService(_context);
        _combatService = new CombatService(_playerService);
        _questService = new QuestService(_context);
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

            string? choice = Console.ReadLine();
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
                    var player = _playerService.GetPlayer();
                    var currentLocation = _locationService.GetCurrentLocation();
                    _combatService.AttackEnemies(player, currentLocation);
                    break;

                case "4":
                    _merchantService.DisplayVisitMessage(_playerService.GetPlayer());
                    break;
                case "5":
                    _playerService.ViewCurrentQuests();
                    break;
                case "6":
                    var quest = _locationService.GetQuestInCurrentLocation();
                    _questService.PickUpQuest(_playerService.GetPlayer(), quest);
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