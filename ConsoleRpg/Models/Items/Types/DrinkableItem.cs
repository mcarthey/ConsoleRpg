using ConsoleRpg.Entities;

namespace ConsoleRpg.Models.Items.Types;

public abstract class DrinkableItem : Item, IDrinkable
{
    public bool IsPotable { get; set; }
    public int Quantity { get; set; }

    public virtual void Drink(Character character)
    {
        if (!IsPotable)
        {
            throw new InvalidOperationException("This item is not potable.");
        }

        if (Quantity <= 0)
        {
            throw new InvalidOperationException("This item is empty.");
        }

        Quantity--;
    }
}

public interface IDrinkable
{
    bool IsPotable { get; set; }
    int Quantity { get; set; }

    void Drink(Character character);
}

