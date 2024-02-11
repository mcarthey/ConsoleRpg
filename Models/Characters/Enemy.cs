using ConsoleRpg.Entities;

namespace ConsoleRpg.Models.Characters
{
    public class Enemy : Character
    {
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
}
