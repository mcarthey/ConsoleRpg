using ConsoleRpg.Entities;

namespace ConsoleRpg.Models.Items.Types;

public interface ISellable
{
    int Price { get; set; }

    int Sell(Character character);

}
