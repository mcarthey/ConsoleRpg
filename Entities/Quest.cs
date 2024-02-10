namespace ConsoleRpg.Entities;

// A quest belongs to a player.
// Add a PlayerId property to link each quest to a player
public class Quest
{
    public string Description { get; set; }
    public int Id { get; set; }
    public bool IsCompleted { get; set; }
    public virtual Location Location { get; set; }
    public int? NpcId { get; set; } // Foreign key property
    public virtual Npc Npc { get; set; } // Navigation property

    public int? LocationId { get; set; }
    public string Name { get; set; }

    public virtual List<Player> Players { get; set; }
    public int RewardExperience { get; set; }
    public int RewardGold { get; set; }

    public int KillCount { get; set; } // Number of enemies to kill to complete the quest
    public int KillCountProgress { get; set; } // Current progress towards KillCount

}
