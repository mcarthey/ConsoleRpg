﻿namespace ConsoleRpg.Entities;

// A quest belongs to a player.
// Add a PlayerId property to link each quest to a player
public class Quest
{
    public string Description { get; set; }
    public int Id { get; set; }
    public bool IsCompleted { get; set; }
    public virtual Location Location { get; set; }

    public int? LocationId { get; set; }
    public string Name { get; set; }

    public virtual List<Player> Players { get; set; }
    public int RewardExperience { get; set; }
    public int RewardGold { get; set; }
}
