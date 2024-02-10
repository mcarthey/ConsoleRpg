using ConsoleRpg.Entities;

public class LootTable
{
    public int Id { get; set; }
    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
    public int? EnemyId { get; set; } // Foreign key property
    public virtual Enemy Enemy { get; set; } // Navigation property

    public Item GetRandomItem()
    {
        Random random = new Random();
        int index = random.Next(Items.Count);
        return Items.ElementAt(index);
    }
}
