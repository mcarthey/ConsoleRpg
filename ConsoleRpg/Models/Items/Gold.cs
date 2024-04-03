using ConsoleRpg.Entities;
using ConsoleRpg.Models.Items.Types;

namespace ConsoleRpg.Models.Items;

public class Gold : Item
{
    public int Amount { get; set; }
    public int Denomination { get; set; }

}