using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleRpg.Entities;

public abstract class Character
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Health { get; set; }
    public int MaxHealth { get; set; }
    public int Attack { get; set; }
    public int Damage { get; set; }
    public int Experience { get; set; }

    // entity framework navigation properties
    public int InventoryId { get; set; }

    // Do not initialize Inventory here because Entity Framework will take care of creating the Inventory instance when a new Character is created.
    // If you initialize Inventory in the Character class, it might cause issues with Entity Framework's change tracking.
    public virtual Inventory Inventory { get; set; } 

    public int LocationId { get; set; }

    public virtual Location Location { get; set; }
}