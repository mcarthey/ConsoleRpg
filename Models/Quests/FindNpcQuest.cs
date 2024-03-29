using ConsoleRpg.Entities;
using ConsoleRpg.Utils;

namespace ConsoleRpg.Models.Quests;

public class FindNpcQuest : Quest
{
    public string TargetNpc { get; set; } // The NPC to find to complete the quest

    public override void DisplayProgress()
    {
        CustomConsole.Info($"Target NPC: {TargetNpc}");
    }
}