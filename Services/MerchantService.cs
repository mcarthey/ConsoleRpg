using ConsoleRpg.Entities;

namespace ConsoleRpg.Services;

public class MerchantService
{
    private RpgContext _context;
    private Merchant _merchant;

    public MerchantService(RpgContext context)
    {
        _context = context;
        _merchant = GetMerchant();
    }

    // GetMerchant, VisitMerchant methods go here...
    public Merchant GetMerchant()
    {
        return _context.Merchants.FirstOrDefault() ?? throw new Exception("No merchant found.");
    }

    public void VisitMerchant(Player player)
    {
        Console.WriteLine($"Welcome to {_merchant.Name}'s shop!");
        Console.WriteLine("Available items:");
        foreach (var item in _merchant.Inventory)
        {
            Console.WriteLine($"{item.Name}: {item.Description}, Cost: {item.Cost} gold");
        }

        Console.WriteLine("What would you like to buy? (Enter item name or 'exit' to leave)");
        string? itemName = Console.ReadLine();
        if (itemName == null)
        {
            throw new Exception("Failed to read item name.");
        }
        if (itemName.ToLower() == "exit")
        {
            return;
        }

        Item? selectedItem = _merchant.Inventory.FirstOrDefault(i => i.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
        if (selectedItem == null)
        {
            Console.WriteLine("Item not found.");
            return;
        }
        if (player.Gold < selectedItem.Cost)
        {
            Console.WriteLine("Not enough gold to purchase this item.");
            return;
        }
        player.Gold -= selectedItem.Cost;
        player.Inventory.Add(selectedItem);
        _context.SaveChanges(); // Save changes after buying an item
        Console.WriteLine($"You purchased {selectedItem.Name}.");
    }

}