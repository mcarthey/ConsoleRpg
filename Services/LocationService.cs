using ConsoleRpg.Context;
using ConsoleRpg.Entities;
using Spectre.Console;

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
        CustomConsole.Notice($"You are now in {location.Name}");
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
        CustomConsole.Info($"You have moved to {_currentLocation.Name}");
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
        CustomConsole.Prompt("Where would you like to move?");
        for (var i = 0; i < locations.Count; i++)
        {
            CustomConsole.Info($"{i + 1}. {locations[i].Name}");
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
        CustomConsole.Info("\n-------------------------");
        CustomConsole.Info($"{location.Description}\n");
        Console.ResetColor();

        // Display the items in the location
        if (location.Items.Any())
        {
            CustomConsole.Notice("Items in this location:");
            foreach (var item in location.Items)
            {
                CustomConsole.Info($"- {item.Name}: {item.Description}");
            }
        }
        else
        {
            CustomConsole.Notice("There are no items in this location.");
        }

        Console.WriteLine();

        // Display the enemies in the location
        if (location.Enemies.Any())
        {
            CustomConsole.Notice("Enemies in this location:");
            foreach (var enemy in location.Enemies)
            {
                CustomConsole.Info($"- {enemy.Name}: {enemy.Description}");
            }
        }
        else
        {
            CustomConsole.Notice("There are no enemies in this location.");
        }

        Console.WriteLine();

        // Display the quest in the location
        if (location.Quest != null)
        {
            CustomConsole.Notice("Quest in this location:");
            CustomConsole.Info($"- {location.Quest.Name}: {location.Quest.Description}");
        }
        else
        {
            CustomConsole.Notice("There is no quest in this location.");
        }

        Console.WriteLine();

        // Display the exits in the location
        if (location.Exits.Any())
        {
            CustomConsole.Notice("Exits from this location:");
            foreach (var exit in location.Exits)
            {
                CustomConsole.Info($"- {exit.Direction}");
            }
        }
        else
        {
            CustomConsole.Notice("There are no exits from this location.");
        }

        CustomConsole.Info("-------------------------\n");
    }
}
