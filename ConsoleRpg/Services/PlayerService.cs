using ConsoleRpg.Context;
using ConsoleRpg.Dao;
using ConsoleRpg.Entities;
using ConsoleRpg.Models.Characters;
using ConsoleRpg.Models.Items;
using ConsoleRpg.Utils;
using System.Numerics;

namespace ConsoleRpg.Services;

public class PlayerService : IPlayerService
{
    private readonly IInventoryService _inventoryService;
    private Player _player;

    public PlayerService(IInventoryService inventoryService)
    {
        _inventoryService = inventoryService;
    }

    public Player GetPlayer()
    {
        return _player ?? throw new Exception("Player not loaded.");
    }

    public void GainExperience(int amount)
    {
        _player.Experience += amount;
        CustomConsole.Info($"Player gains {amount} experience points.");
    }

    public void Login(Player currentPlayer)
    {
        _player = currentPlayer;
        _inventoryService.InitializeInventory(currentPlayer);
    }

    public void Logout()
    {
        _player = null;
    }

    public void AddItemToInventory(Item item)
    {
        _inventoryService.AddItemToInventory(item);
    }

    public void RemoveItemFromInventory(Item item)
    {
        _inventoryService.RemoveItemFromInventory(item);
    }

    public Item GetRandomItemFromInventory()
    {
        return _inventoryService.GetRandomItemFromInventory();
    }

    public void AddGold(int amount)
    {
        _inventoryService.AddGold(amount);
    }

    public void SubtractGold(int amount)
    {
        _inventoryService.SubtractGold(amount);
    }

    public int GetGoldAmount()
    {
        return _inventoryService.GetGoldAmount();
    }
}
