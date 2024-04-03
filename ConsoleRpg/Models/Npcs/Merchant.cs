using System.ComponentModel.DataAnnotations.Schema;
using ConsoleRpg.Entities;
using ConsoleRpg.Models.Items.Types;

namespace ConsoleRpg.Models.Npcs;

public class Merchant : Npc
{
    public virtual List<Item> Inventory { get; set; }

}
