using ConsoleRpg.Models.Characters;

namespace ConsoleRpg.Entities;

// An item belongs to a player and a merchant.
// Add PlayerId and MerchantId properties to link each item to a player and a merchant
public abstract class Item
{
    public int Cost { get; set; }
    public string Description { get; set; }
    public int Id { get; set; }
    public virtual Location Location { get; set; } // Navigation property
    public int? LocationId { get; set; } // Foreign key property
    public int? MerchantId { get; set; } // This is the foreign key for Merchant
    public string Name { get; set; }
    public int? PlayerId { get; set; } // This is the foreign key for Player

    public Player? Player { get; set; } // Navigation property
    // You can add common methods for all items here
}
