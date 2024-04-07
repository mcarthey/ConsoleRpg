using ConsoleRpg.Commands;
using ConsoleRpg.Entities;
using ConsoleRpg.Models.Items;
using ConsoleRpg.Dao;

public class DrinkPotionCommand : ICommand
{
    private readonly IInventoryService _inventoryService;
    private readonly CharacterRepository _characterRepository;
    private readonly int _characterId; // The ID of the character who will drink the potion

    public DrinkPotionCommand(IInventoryService inventoryService, CharacterRepository characterRepository, int characterId)
    {
        _inventoryService = inventoryService;
        _characterRepository = characterRepository;
        _characterId = characterId;
    }

    public void Execute(string[] parameters)
    {
        if (parameters.Length == 0)
        {
            throw new ArgumentException("A potion name must be provided.");
        }

        var potionName = parameters[0];
        var potion = _inventoryService.GetItem(potionName) as Potion;

        if (potion == null)
        {
            throw new InvalidOperationException($"Potion '{potionName}' not found in inventory.");
        }

        var character = _characterRepository.GetCharacter(_characterId);
        potion.Drink(character);

        _inventoryService.RemoveItem(potion);
    }
}
