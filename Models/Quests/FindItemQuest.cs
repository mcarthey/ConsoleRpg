using ConsoleRpg.Entities;

public class FindItemQuest : Quest
{
    public string TargetItem { get; set; } // The item to find to complete the quest

    public override void DisplayProgress()
    {
        Console.WriteLine($"Target item: {TargetItem}");
    }
}
