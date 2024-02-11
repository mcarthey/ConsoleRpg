using ConsoleRpg.Models.Characters;

namespace ConsoleRpg.Entities;

public class LootTable
{
    public int Id { get; set; }
    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
    public int? EnemyId { get; set; } // Foreign key property
    public virtual Enemy Enemy { get; set; } // Navigation property

}