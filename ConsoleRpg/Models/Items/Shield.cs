using ConsoleRpg.Entities;
using ConsoleRpg.Models.Items.Types;

namespace ConsoleRpg.Models.Items;

public class Shield : BreakableItem, ISellable
{
    public int Defense { get; set; }

    public int Price { get; set; }
    public int Sell(Character character)
    {
        return Price;
    }

    public int Sell()
    {
        return Price;
    }

    public override void PerformAction(Character character)
    {
        Sell(character);
    }
}