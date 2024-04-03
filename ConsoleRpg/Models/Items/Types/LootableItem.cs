using ConsoleRpg.Entities;

namespace ConsoleRpg.Models.Items.Types;

public abstract class LootableItem : Item, ILootable
{
    public int Probability { get; set; }

    public bool Loot()
    {
        var random = new Random();
        return random.Next(100) < Probability;
    }
}



public interface ILootable
{
    int Probability { get; set; }
    bool Loot();
}