using System.ComponentModel.DataAnnotations.Schema;
using ConsoleRpg.Entities;
using ConsoleRpg.Models.Items;
using ConsoleRpg.Utils;

namespace ConsoleRpg.Models.Characters
{
    public class Player : Character
    {
        public int Gold { get; set; }
        public virtual ICollection<Sword> Swords { get; set; } = new List<Sword>();
        public virtual ICollection<Shield> Shields { get; set; } = new List<Shield>();
        public virtual ICollection<Potion> Potions { get; set; } = new List<Potion>();
        public virtual ICollection<Gold> Golds { get; set; } = new List<Gold>();
        [ForeignKey("PlayerId")] public virtual List<Item> Inventory { get; set; } = new List<Item>();
        public virtual List<Quest> ActiveQuests { get; set; } = new List<Quest>();

        public void GainExperience(int amount)
        {
            Experience += amount;
            CustomConsole.Info($"Player gains {amount} experience points.");
        }
    }
}
