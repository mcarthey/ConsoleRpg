using ConsoleRpg.Services;

namespace ConsoleRpg.Commands;

public class CheckInventoryCommand : ICommand
{
    private readonly IInventoryService _inventoryService;

    public CheckInventoryCommand(IInventoryService inventoryService)
    {
        _inventoryService = inventoryService;
    }

    public void Execute(string[] parameters)
    {
        _inventoryService.DisplayInventory();
    }
}
