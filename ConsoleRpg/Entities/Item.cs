using ConsoleRpg.Models.Characters;

namespace ConsoleRpg.Entities;

public abstract class Item
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    // Navigation property
    public virtual Location Location { get; set; } 
    public int? LocationId { get; set; }

}
