using ConsoleRpg.Entities;
using ConsoleRpg.Services;
using ConsoleRpg.Utils;

namespace ConsoleRpg.Models.Quests;

public class FindLocationQuest : Quest
{
    public string TargetLocation { get; set; } // The location to find to complete the quest
    private readonly ILocationService _locationService;
    private readonly Character _character;

    public FindLocationQuest(ILocationService locationService, Character character)
    {
        _locationService = locationService;
        _character = character;
    }

    public override void DisplayProgress()
    {
        CustomConsole.Info($"Target location: {TargetLocation}");
    }

    public override bool CheckIfCompleted()
    {
        var currentLocation = _locationService.GetLocationById(_character.LocationId);
        return currentLocation.Name == TargetLocation;
    }
}
