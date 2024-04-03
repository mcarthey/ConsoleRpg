using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleRpg.Entities;

public class Inventory
{
    public int Id { get; set; }

    public int CharacterId { get; set; }

    [ForeignKey("CharacterId")]
    public virtual Character Character { get; set; }
    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}