using ConsoleRpg.Entities;

namespace ConsoleRpg.Services;

public interface ILocationService
{
    void DisplayLocationDetails(Location location);
    List<Location> GetAllLocations();
    Location GetStartingLocation();
    void Move(Location newLocation);
    Location GetRandomLocation();
    Location GetLocationById(int id);
}