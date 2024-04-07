using ConsoleRpg.Models.Characters;
using ConsoleRpg.Utils;

namespace ConsoleRpg.Entities;

public abstract class Item
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    // Navigation property
    public virtual Location Location { get; set; } 
    public int? LocationId { get; set; }

    public int? InventoryId { get; set; }
    public virtual Inventory Inventory { get; set; }

    public abstract void PerformAction(Character character);

    public virtual void Display()
    {
        CustomConsole.Info($"{Name}: {Description}");
    }
}
