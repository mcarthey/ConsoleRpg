using ConsoleRpg.Services;

namespace ConsoleRpg.Commands;

public class MoveToLocationCommand : ICommand
{
    private readonly LocationService _locationService;

    public MoveToLocationCommand(LocationService locationService)
    {
        _locationService = locationService;
    }

    public void Execute(string[] parameters)
    {
        if (parameters.Length > 0)
        {
            var locationName = parameters[0];
            var location = _locationService.GetAllLocations().FirstOrDefault(l => l.Name == locationName);
            if (location != null)
            {
                _locationService.Move(location);
            }
        }
    }
}