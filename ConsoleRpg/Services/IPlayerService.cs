using ConsoleRpg.Entities;
using ConsoleRpg.Models.Characters;

public interface IPlayerService
{
    Player GetPlayer();
    void GainExperience(int amount);
    void Login(Player currentPlayer);
    void Logout();
    void AddItemToInventory(Item item);
    void RemoveItemFromInventory(Item item);
    Item GetRandomItemFromInventory();
    void AddGold(int amount);
    void SubtractGold(int amount);
    int GetGoldAmount();
}
