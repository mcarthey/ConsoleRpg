using ConsoleRpg.Entities;

namespace ConsoleRpg.Services;

public class LocationService
{
    private readonly RpgContext _context;
    private Location _currentLocation;

    public LocationService(RpgContext context)
    {
        _context = context;
        _currentLocation = GetStartingLocation();
    }

    public void DisplayLocationDetails(Location location)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"You are now in {location.Name}");
        Console.ResetColor();
        DisplayLocationContents(location);
    }

    public List<Location> GetAllLocations()
    {
        return _context.Locations.ToList();
    }

    public Location GetCurrentLocation()
    {
        return _currentLocation;
    }

    public Quest GetQuestInCurrentLocation()
    {
        return _currentLocation.Quest;
    }

    // GetStartingLocation, Move methods go here...
    public Location GetStartingLocation()
    {
        return _context.Locations.FirstOrDefault() ?? throw new Exception("No starting location found.");
    }

    public void Move(Location newLocation)
    {
        _currentLocation = newLocation;
        Console.WriteLine($"You have moved to {_currentLocation.Name}");
        DisplayLocationDetails(_currentLocation);
    }

    public Location GetRandomLocation()
    {
        var locations = GetAllLocations();
        var randomIndex = new Random().Next(locations.Count);
        return locations[randomIndex];
    }

    public void MoveToLocation()
    {
        var locations = GetAllLocations();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Where would you like to move?");
        Console.ResetColor();
        for (var i = 0; i < locations.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {locations[i].Name}");
        }

        var locationChoiceString = Console.ReadLine();
        if (locationChoiceString == null)
        {
            throw new Exception("Failed to read choice.");
        }

        var locationChoice = int.Parse(locationChoiceString);
        Move(locations[locationChoice - 1]);
    }

    private void DisplayLocationContents(Location location)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n-------------------------");
        Console.WriteLine($"Location: {location.Name}\n");
        Console.WriteLine($"{location.Description}\n");
        Console.ResetColor();

        // Display the items in the location
        if (location.Items.Any())
        {
            Console.WriteLine("Items in this location:");
            foreach (var item in location.Items)
            {
                Console.WriteLine($"- {item.Name}: {item.Description}");
            }
        }
        else
        {
            Console.WriteLine("There are no items in this location.");
        }

        Console.WriteLine();

        // Display the enemies in the location
        if (location.Enemies.Any())
        {
            Console.WriteLine("Enemies in this location:");
            foreach (var enemy in location.Enemies)
            {
                Console.WriteLine($"- {enemy.Name}: {enemy.Description}");
            }
        }
        else
        {
            Console.WriteLine("There are no enemies in this location.");
        }

        Console.WriteLine();

        // Display the quest in the location
        if (location.Quest != null)
        {
            Console.WriteLine("Quest in this location:");
            Console.WriteLine($"- {location.Quest.Name}: {location.Quest.Description}");
        }
        else
        {
            Console.WriteLine("There is no quest in this location.");
        }

        Console.WriteLine();

        // Display the exits in the location
        if (location.Exits.Any())
        {
            Console.WriteLine("Exits from this location:");
            foreach (var exit in location.Exits)
            {
                Console.WriteLine($"- {exit.Direction}");
            }
        }
        else
        {
            Console.WriteLine("There are no exits from this location.");
        }

        Console.WriteLine("-------------------------\n");
    }
}
