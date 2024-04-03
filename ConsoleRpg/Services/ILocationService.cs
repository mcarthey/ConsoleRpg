using ConsoleRpg.Entities;

public interface ILocationService
{
    void DisplayLocationDetails(Location location);
    List<Location> GetAllLocations();
    Location GetStartingLocation();
    void Move(Location newLocation);
    Location GetRandomLocation();
}
