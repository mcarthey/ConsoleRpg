using ConsoleRpg.Models;

namespace ConsoleRpg.Entities;

// An enemy belongs to a location.
// Add a LocationId property to link each enemy to a location
public class Enemy : Character
{
    public int Id { get; set; }
    public virtual Location? Location { get; set; } // Navigation property
    public int LocationId { get; set; } // Foreign key property
    public int? QuestId { get; set; } // Foreign key property
    public virtual Quest? Quest { get; set; } // Navigation property
    public int? LootTableId { get; set; } // Foreign key property
    public virtual LootTable? LootTable { get; set; } // Navigation property

    public void Respawn(Location newLocation)
    {
        Health = MaxHealth; // Reset health to max health
        Location = newLocation; // Set new location
        LocationId = newLocation.Id; // Update foreign key
    }
}
