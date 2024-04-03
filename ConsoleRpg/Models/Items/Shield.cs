using ConsoleRpg.Entities;
using ConsoleRpg.Models.Items.Types;

namespace ConsoleRpg.Models.Items;

public class Shield : BreakableItem, ISellable
{
    public int Defense { get; set; }

    public int Price { get; set; }
    public int Sell()
    {
        return Price;
    }
}