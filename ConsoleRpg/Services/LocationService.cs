using ConsoleRpg.Context;
using ConsoleRpg.Dao;
using ConsoleRpg.Entities;
using ConsoleRpg.Utils;

namespace ConsoleRpg.Services;

public class LocationService : ILocationService
{
    private readonly LocationRepository _locationRepository;

    public LocationService(LocationRepository locationRepository)
    {
        _locationRepository = locationRepository;
    }

    public void DisplayLocationDetails(Location location)
    {
        CustomConsole.Notice($"You are now in {location.Name}");
        DisplayLocationContents(location);
    }

    public List<Location> GetAllLocations()
    {
        return _locationRepository.GetAllLocations();
    }

    public Location GetStartingLocation()
    {
        return _locationRepository.GetStartingLocation();
    }

    public void Move(Location newLocation)
    {
        CustomConsole.Info($"You have moved to {newLocation.Name}");
        DisplayLocationDetails(newLocation);
    }

    public Location GetRandomLocation()
    {
        var locations = GetAllLocations();
        var randomIndex = new Random().Next(locations.Count);
        return locations[randomIndex];
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

        // Display the characters in the location
        if (location.Characters.Any())
        {
            CustomConsole.Notice("Characters in this location:");
            foreach (var character in location.Characters)
            {
                CustomConsole.Info($"- {character.Name}: {character.Description}");
            }
        }
        else
        {
            CustomConsole.Notice("There are no characters in this location.");
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

        CustomConsole.Info("-------------------------\n");
    }
}
