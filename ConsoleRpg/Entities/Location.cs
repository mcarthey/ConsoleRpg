using ConsoleRpg.Models.Characters;

namespace ConsoleRpg.Entities;

// A location has a list of enemies and a list of items.
// Initialize these lists in the constructor
public class Location
{
    public int Id { get; set; } // This is the primary key
    public string Name { get; set; }
    public string Description { get; set; }

    public virtual List<Character> Characters { get; set; }
    public virtual List<Item> Items { get; set; }

    public virtual Quest Quest { get; set; }
    
    public Location()
    {
        Characters = new List<Character>();
        Items = new List<Item>();
    }
}
