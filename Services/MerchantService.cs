using ConsoleRpg.Context;
using ConsoleRpg.Entities;
using ConsoleRpg.Models.Items;

namespace ConsoleRpg.Services;

public class MerchantService
{
    private readonly RpgContext _context;
    private readonly Merchant _merchant;
    private readonly PlayerService _playerService;

    public MerchantService(RpgContext context, PlayerService playerService)
    {
        _context = context;
        _merchant = GetMerchant();
        _playerService = playerService;
    }

    public void DisplayVisitMessage()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("Visiting the merchant...");
        Console.ResetColor();
        VisitMerchant();
    }

    // GetMerchant, VisitMerchant methods go here...
    public Merchant GetMerchant()
    {
        return _context.Merchants.FirstOrDefault() ?? throw new Exception("No merchant found.");
    }

    public void VisitMerchant()
    {
        var player = _playerService.GetPlayer();
        Console.WriteLine($"Welcome to {_merchant.Name}'s shop!");
        Console.WriteLine($"You currently have {player.Gold} gold.");

        Console.WriteLine("Available items:");
        foreach (var item in _merchant.Inventory)
        {
            Console.WriteLine($"{item.Name}: {item.Description}, Cost: {item.Cost} gold");
        }

        Console.WriteLine("What would you like to buy? (Enter item name or 'exit' to leave)");
        var itemName = Console.ReadLine();
        if (itemName == null)
        {
            throw new Exception("Failed to read item name.");
        }

        if (itemName.ToLower() == "exit")
        {
            return;
        }

        var selectedItem = _context.Items.FirstOrDefault(i => i.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase) && i is Sword)
            ?? _context.Items.FirstOrDefault(i => i.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase) && i is Shield)
            ?? _context.Items.FirstOrDefault(i => i.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase) && i is Potion)
            ?? _context.Items.FirstOrDefault(i => i.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase) && i is Gold);


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