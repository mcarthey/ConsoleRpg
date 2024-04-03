using ConsoleRpg.Services;

namespace ConsoleRpg.Commands;

public class CheckInventoryCommand : ICommand
{
    private readonly InventoryService _inventoryService;

    public CheckInventoryCommand(InventoryService inventoryService)
    {
        _inventoryService = inventoryService;
    }

    public void Execute(string[] parameters)
    {
        _inventoryService.DisplayInventory();
    }
}
