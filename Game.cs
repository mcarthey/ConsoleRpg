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

    public Game()
    {
        _context = new RpgContext();
        _playerService = new PlayerService(_context);
        _locationService = new LocationService(_context);
        _merchantService = new MerchantService(_context);
        _combatService = new CombatService();
    }

    public void Start()
    {
        var startingLocation = _locationService.GetStartingLocation();
        Console.WriteLine("Welcome to the Text RPG!");
        _locationService.DisplayLocationDetails(startingLocation);

        //Console.WriteLine($"You are currently in {startingLocation.Name}");
        //Console.WriteLine(startingLocation.Description);
        while (true)
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Move to another location");
            Console.WriteLine("2. Check inventory");
            Console.WriteLine("3. Attack enemies");
            Console.WriteLine("4. Visit the merchant");
            Console.WriteLine("5. View current quests");
            Console.WriteLine("6. Quit");

            string? choice = Console.ReadLine();
            if (choice == null)
            {
                throw new Exception("Failed to read choice.");
            }
            switch (choice)
            {
                case "1":
                    var locations = _locationService.GetAllLocations();
                    Console.WriteLine("Where would you like to move?");
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
                    _playerService.ShowInventory();
                    break;
                case "3":
                    var player = _playerService.GetPlayer();
                    var currentLocation = _locationService.GetCurrentLocation(); 
                    var enemies = currentLocation.Enemies; 
                    foreach (var enemy in enemies)
                    {
                        _combatService.Combat(player, enemy);
                    }
                    break;

                case "4":
                    _merchantService.VisitMerchant(_playerService.GetPlayer());
                    break;
                case "5":
                    _playerService.ShowActiveQuests();
                    break;
                case "6":
                    _playerService.SavePlayer();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

}