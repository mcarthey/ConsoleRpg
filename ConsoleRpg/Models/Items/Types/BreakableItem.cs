using ConsoleRpg.Entities;

namespace ConsoleRpg.Models.Items.Types;

public abstract class BreakableItem : Item, IBreakable
{
    public int Durability { get; set; }

    public void Damage(int amount)
    {
        Durability -= amount;
        if (Durability < 0)
        {
            Durability = 0;
        }
    }
}

public interface IBreakable
{
    int Durability { get; set; }

    void Damage(int amount);
}