using System.ComponentModel.DataAnnotations.Schema;
using ConsoleRpg.Entities;
using ConsoleRpg.Models.Items;
using ConsoleRpg.Utils;

namespace ConsoleRpg.Models.Characters
{
    public class Player : Character
    {
        public virtual Inventory Inventory { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
