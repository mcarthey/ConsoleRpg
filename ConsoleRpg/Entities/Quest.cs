using ConsoleRpg.Models.Characters;

namespace ConsoleRpg.Entities;

// A quest belongs to a player.
// Add a PlayerId property to link each quest to a player
public abstract class Quest
{
    public Quest()
    {
        // Initialize Players list to avoid NullReferenceException when trying to add a player to it.
        // This doesn't assume that a player will pick up the quest, it simply ensures that the list is ready to be used when needed.
        Players = new List<Player>();
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public int RewardExperience { get; set; }
    public int RewardGold { get; set; }
    public int KillCount { get; set; } // Number of enemies to kill to complete the quest
    public int KillCountProgress { get; set; } // Current progress towards KillCount

    public string Target { get; set; }

    // navigation properties
    public int LocationId { get; set; }
    public virtual Location Location { get; set; }
    public int? NpcId { get; set; } // Foreign key property
    public virtual Npc Npc { get; set; } // Navigation property
    public virtual List<Player> Players { get; set; }
    public virtual List<Item> RewardItems { get; set; }

    public abstract void DisplayProgress();
    public abstract bool CheckIfCompleted();
    public virtual void RewardPlayer(Player player)
    {
        foreach (var item in RewardItems)
        {
            player.Inventory.Items.Add(item);
        }
    }


}

