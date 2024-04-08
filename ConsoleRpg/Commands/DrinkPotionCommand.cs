using ConsoleRpg.Models.Items;
using ConsoleRpg.Services;

namespace ConsoleRpg.Commands;

public class DrinkPotionCommand : ICommand
{
    private readonly IInventoryService _inventoryService;
    private readonly CharacterService _characterService;
    private readonly int _characterId; // The ID of the character who will drink the potion

    public DrinkPotionCommand(IInventoryService inventoryService, CharacterService characterService, int characterId)
    {
        _inventoryService = inventoryService;
        _characterService = characterService;
        _characterId = characterId;
    }

    public void Execute(string[] parameters)
    {
        if (parameters.Length == 0 || string.IsNullOrEmpty(parameters[0]))
        {
            throw new ArgumentException("A potion name must be provided.");
        }

        var potionName = parameters[0];
        var potion = _inventoryService.GetItem(potionName) as Potion;

        if (potion == null)
        {
            throw new InvalidOperationException($"Potion '{potionName}' not found in inventory.");
        }

        var character = _characterService.GetCharacter(_characterId);
        potion.Drink(character);

        _inventoryService.RemoveItem(potion);
        _characterService.SaveCharacter(character);
    }
}