using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleRpg.Entities
{
    // A merchant has a list of items (Inventory).
    // Initialize this list in the constructor and add a ForeignKey attribute to the Inventory property
    public class Merchant
    {
        public Merchant()
        {
            Inventory = new List<Item>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("MerchantId")]
        public virtual List<Item> Inventory { get; set; }
    }
}
