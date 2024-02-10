using System.ComponentModel.DataAnnotations.Schema;
using ConsoleRpg.Models;

namespace ConsoleRpg.Entities;

// A player has a list of items (Inventory) and a list of quests (ActiveQuests).
// Initialize these lists in the constructor and add a ForeignKey attribute to the Inventory property
public class Player : Character
{
    public virtual List<Quest> ActiveQuests { get; set; }
    public int Gold { get; set; }

    public int Id { get; set; }

    [ForeignKey("PlayerId")] public virtual List<Item> Inventory { get; set; }

    public Player()
    {
        Inventory = new List<Item>();
        ActiveQuests = new List<Quest>();
    }

    public void GainExperience(int amount)
    {
        Experience += amount;
        Console.WriteLine($"Player gains {amount} experience points.");
    }
}
