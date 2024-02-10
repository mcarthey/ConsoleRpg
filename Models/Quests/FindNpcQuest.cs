using ConsoleRpg.Entities;

public class FindNpcQuest : Quest
{
    public string TargetNpc { get; set; } // The NPC to find to complete the quest

    public override void DisplayProgress()
    {
        Console.WriteLine($"Target NPC: {TargetNpc}");
    }
}
