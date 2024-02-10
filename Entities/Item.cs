namespace ConsoleRpg.Entities
{
    // An item belongs to a player and a merchant.
    // Add PlayerId and MerchantId properties to link each item to a player and a merchant
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Cost { get; set; }
        public int? PlayerId { get; set; } // This is the foreign key for Player
        public int? MerchantId { get; set; } // This is the foreign key for Merchant
        public int? LocationId { get; set; } // Foreign key property
        public virtual Location Location { get; set; } // Navigation property

    }
}
