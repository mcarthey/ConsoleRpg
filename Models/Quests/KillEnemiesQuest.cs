using ConsoleRpg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRpg.Models.Quests
{
    public class KillEnemiesQuest : Quest
    {
        public int KillCount { get; set; } // Number of enemies to kill to complete the quest
        public int KillCountProgress { get; set; } // Current progress towards KillCount

        public override void DisplayProgress()
        {
            CustomConsole.Info($"Kill count progress: {KillCountProgress}/{KillCount}");
        }
    }
}
