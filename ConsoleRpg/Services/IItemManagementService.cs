using ConsoleRpg.Entities;

public interface IItemManagementService<T> where T : Item
{
    void PerformAction(T item);
}
