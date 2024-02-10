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


    public void Move()
    {
        Console.WriteLine("Available exits:");
        foreach (var exit in _currentLocation.Exits)
        {
            Console.WriteLine(exit.Direction);
        }

        Console.Write("Enter direction to move: ");
        string direction = Console.ReadLine();
        if (direction == null)
        {
            throw new Exception("Failed to read direction.");
        }
        direction = direction.ToLower();

        var chosenExit = _currentLocation.Exits.FirstOrDefault(e => e.Direction == direction);
        if (chosenExit != null)
        {
            _currentLocation = chosenExit.Location;
            Console.WriteLine($"You have moved to {_currentLocation.Name}");
            Console.WriteLine(_currentLocation.Description);
        }
        else
        {
            Console.WriteLine("Invalid direction.");
        }

        // After moving to the new location, display its contents
        Console.WriteLine($"You are now in {_currentLocation.Name}");
        Console.WriteLine(_currentLocation.Description);

        // Display the items in the location
        if (_currentLocation.Items.Any())
        {
            Console.WriteLine("Items in this location:");
            foreach (var item in _currentLocation.Items)
            {
                Console.WriteLine($"{item.Name}: {item.Description}");
            }
        }
        else
        {
            Console.WriteLine("There are no items in this location.");
        }

        // Display the enemies in the location
        if (_currentLocation.Enemies.Any())
        {
            Console.WriteLine("Enemies in this location:");
            foreach (var enemy in _currentLocation.Enemies)
            {
                Console.WriteLine($"{enemy.Name}: {enemy.Description}");
            }
        }
        else
        {
            Console.WriteLine("There are no enemies in this location.");
        }
    }
}