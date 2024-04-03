using ConsoleRpg.Entities;
using ConsoleRpg.Models.Characters;

public interface ISessionService
{
    User CurrentUser { get; }
    Player CurrentPlayer { get; }
    void Login(string username);
    void Logout();
    void GainExperience(int amount);
}
