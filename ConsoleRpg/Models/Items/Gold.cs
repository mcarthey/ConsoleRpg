using ConsoleRpg.Entities;
using ConsoleRpg.Models.Items.Types;

namespace ConsoleRpg.Models.Items;

public class Gold : Item, IValuable
{
    public int Value { get; set; }
    public ValuableType Type => ValuableType.Gold;
    public int Denomination { get; set; }

}