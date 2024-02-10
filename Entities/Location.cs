namespace ConsoleRpg.Entities;

// A location has a list of enemies and a list of items.
// Initialize these lists in the constructor
public class Location
{
    public string Description { get; set; }
    public virtual List<Enemy> Enemies { get; set; }
    public virtual List<Exit> Exits { get; set; }

    public int Id { get; set; } // This is the primary key
    public virtual List<Item> Items { get; set; }
    public string Name { get; set; }
    public virtual Quest Quest { get; set; }

    public Location()
    {
        Enemies = new List<Enemy>();
        Items = new List<Item>();
        Exits = new List<Exit>();
    }
}
