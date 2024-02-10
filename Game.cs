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
        _combatService = new CombatService();
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
                    var locations = _locationService.GetAllLocations();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Where would you like to move?");
                    Console.ResetColor();
                    for (int i = 0; i < locations.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {locations[i].Name}");
                    }
                    string? locationChoiceString = Console.ReadLine();
                    if (locationChoiceString == null)
                    {
                        throw new Exception("Failed to read choice.");
                    }
                    int locationChoice = int.Parse(locationChoiceString);
                    _locationService.Move(locations[locationChoice - 1]);
                    break;
                case "2":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Checking inventory...");
                    Console.ResetColor();
                    _playerService.ShowInventory();
                    break;
                case "3":
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Attacking enemies...");
                    Console.ResetColor();
                    var player = _playerService.GetPlayer();
                    var currentLocation = _locationService.GetCurrentLocation();
                    var enemies = currentLocation.Enemies;
                    foreach (var enemy in enemies)
                    {
                        _combatService.Combat(player, enemy);
                    }
                    break;

                case "4":
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Visiting the merchant...");
                    Console.ResetColor();
                    _merchantService.VisitMerchant(_playerService.GetPlayer());
                    break;
                case "5":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Viewing current quests...");
                    Console.ResetColor();
                    _playerService.ShowActiveQuests();
                    break;
                case "6":
                    var quest = _locationService.GetQuestInCurrentLocation();
                    if (quest != null)
                    {
                        _questService.AddQuest(_playerService.GetPlayer(), quest);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\nYou have picked up a new quest: {quest.Name}\n");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nThere is no quest to pick up in this location.\n");
                        Console.ResetColor();
                    }
                    break;
                case "7":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Saving player and quitting game...");
                    Console.ResetColor();
                    _playerService.SavePlayer();
                    Environment.Exit(0);
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Please try again.");
                    Console.ResetColor();
                    break;
            }
        }
    }

}