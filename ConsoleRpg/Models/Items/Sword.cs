using ConsoleRpg.Entities;
using ConsoleRpg.Models.Items.Types;

namespace ConsoleRpg.Models.Items;

public class Sword : BreakableItem, ISellable
{
    public int Damage { get; set; }

    public int Price { get; set; }
    public int Sell()
    {
        return Price;
    }
}
