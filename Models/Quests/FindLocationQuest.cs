using ConsoleRpg.Entities;

namespace ConsoleRpg.Models.Quests;

public class FindLocationQuest : Quest
{
    public string TargetLocation { get; set; } // The location to find to complete the quest

    public override void DisplayProgress()
    {
        CustomConsole.Info($"Target location: {TargetLocation}");
    }
}