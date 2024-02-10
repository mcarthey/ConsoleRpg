using ConsoleRpg.Entities;

public class FindLocationQuest : Quest
{
    public string TargetLocation { get; set; } // The location to find to complete the quest

    public override void DisplayProgress()
    {
        Console.WriteLine($"Target location: {TargetLocation}");
    }
}
