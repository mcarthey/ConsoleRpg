using ConsoleRpg.Entities;
using ConsoleRpg.Utils;

namespace ConsoleRpg.Models.Quests
{
    public class KillEnemiesQuest : Quest
    {
        public int KillCount { get; set; } // Number of enemies to kill to complete the quest
        public int KillCountProgress { get; set; } // Current progress towards KillCount

        public override bool CheckIfCompleted()
        {
            return KillCount > 0 && KillCountProgress >= KillCount;
        }
        public override void DisplayProgress()
        {
            CustomConsole.Info($"Kill count progress: {KillCountProgress}/{KillCount}");
        }
    }
}
