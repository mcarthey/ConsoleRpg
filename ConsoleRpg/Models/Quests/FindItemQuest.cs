using ConsoleRpg.Entities;
using ConsoleRpg.Models.Characters;
using ConsoleRpg.Utils;

namespace ConsoleRpg.Models.Quests;

public class FindItemQuest : Quest
{
    public string TargetItem { get; set; } // The item to find to complete the quest

    public override void DisplayProgress()
    {
        CustomConsole.Info($"Target item: {TargetItem}");
    }
}