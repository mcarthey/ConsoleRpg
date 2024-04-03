using ConsoleRpg.Context;
using ConsoleRpg.Entities;
using ConsoleRpg.Models.Npcs;

namespace ConsoleRpg.Dao
{
    public class MerchantRepository
    {
        private readonly RpgContext _context;

        public MerchantRepository(RpgContext context)
        {
            _context = context;
        }

        public Merchant GetFirstMerchant()
        {
            return _context.Npcs.OfType<Merchant>().FirstOrDefault();
        }

        public List<Item> GetMerchantInventory(Merchant merchant)
        {
            return merchant?.Inventory?.Cast<Item>().ToList() ?? new List<Item>();
        }

        public Item GetItemFromInventory(Merchant merchant, string itemName)
        {
            return merchant?.Inventory?.Cast<Item>().FirstOrDefault(i => i.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
        }
    }
}
