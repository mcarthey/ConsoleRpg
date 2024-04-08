using ConsoleRpg.Context;
using ConsoleRpg.Entities;

namespace ConsoleRpg.Dao;

public class LocationRepository
{
    private readonly RpgContext _context;

    public LocationRepository(RpgContext context)
    {
        _context = context;
    }

    public List<Location> GetAllLocations()
    {
        return _context.Locations.ToList();
    }

    public Location GetLocationById(int id)
    {
        return _context.Locations.FirstOrDefault(location => location.Id == id);
    }


    public Location GetStartingLocation()
    {
        return _context.Locations.FirstOrDefault() ?? throw new Exception("No starting location found.");
    }

    public Location GetRandomLocation()
    {
        var locations = GetAllLocations();
        var randomIndex = new Random().Next(locations.Count);
        return locations[randomIndex];
    }
}