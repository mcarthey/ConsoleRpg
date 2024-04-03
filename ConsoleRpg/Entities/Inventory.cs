using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleRpg.Entities;

public class Inventory
{
    public int Id { get; set; }
    public virtual ICollection<Item> Items { get; set; } = new List<Item>();

    // Navigation properties
    // Required tells Entity Framework that the Character property in Inventory is required,
    // which means that Inventory is the dependent side of the relationship.
    [Required]
    [ForeignKey("Character")]
    public int CharacterId { get; set; }
    public virtual Character Character { get; set; }
}