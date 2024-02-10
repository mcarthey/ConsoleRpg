using ConsoleRpg.Entities;

namespace ConsoleRpg.Services;

public class LocationService
{
    private RpgContext _context;
    private Location _currentLocation;

    public LocationService(RpgContext context)
    {
        _context = context;
        _currentLocation = GetStartingLocation();
    }

    // GetStartingLocation, Move methods go here...
    public Location GetStartingLocation()
    {
        return _context.Locations.FirstOrDefault() ?? throw new Exception("No starting location found.");
    }

    public Location GetCurrentLocation()
    {
        return _currentLocation;
    }

    public List<Location> GetAllLocations()
    {
        return _context.Locations.ToList();
    }

    public void Move(Location newLocation)
    {
        _currentLocation = newLocation;
        Console.WriteLine($"You have moved to {_currentLocation.Name}");
        DisplayLocationDetails(_currentLocation);
    }

    public void DisplayLocationDetails(Location location)
    {
        Console.WriteLine($"You are now in {location.Name}");
        DisplayLocationContents(location);
    }

    private void DisplayLocationContents(Location location)
    {
        Console.WriteLine(location.Description);

        // Display the items in the location
        if (location.Items.Any())
        {
            Console.WriteLine("Items in this location:");
            foreach (var item in location.Items)
            {
                Console.WriteLine($"{item.Name}: {item.Description}");
            }
        }
        else
        {
            Console.WriteLine("There are no items in this location.");
        }

        // Display the enemies in the location
        if (location.Enemies.Any())
        {
            Console.WriteLine("Enemies in this location:");
            foreach (var enemy in location.Enemies)
            {
                Console.WriteLine($"{enemy.Name}: {enemy.Description}");
            }
        }
        else
        {
            Console.WriteLine("There are no enemies in this location.");
        }

        // Display the quest in the location
        if (location.Quest != null)
        {
            Console.WriteLine("Quest in this location:");
            Console.WriteLine($"{location.Quest.Name}: {location.Quest.Description}");
        }
        else
        {
            Console.WriteLine("There is no quest in this location.");
        }

        // Display the exits in the location
        if (location.Exits.Any())
        {
            Console.WriteLine("Exits from this location:");
            foreach (var exit in location.Exits)
            {
                Console.WriteLine(exit.Direction);
            }
        }
        else
        {
            Console.WriteLine("There are no exits from this location.");
        }
    }
}