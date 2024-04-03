using ConsoleRpg.Dao;
using ConsoleRpg.Entities;
using ConsoleRpg.Models.Characters;
using ConsoleRpg.Utils;
using System;

namespace ConsoleRpg.Services;

public class SessionService : ISessionService
{
    private readonly SessionRepository _sessionRepository;
    private User _currentUser;
    private Player _currentPlayer;

    public SessionService(SessionRepository sessionRepository)
    {
        _sessionRepository = sessionRepository;
    }

    public User CurrentUser => _currentUser;
    public Player CurrentPlayer => _currentPlayer;

    public void Login(string username)
    {
        _currentUser = _sessionRepository.GetUserByUsername(username);
        _currentPlayer = _currentUser?.Player;
        //_inventoryService.InitializeInventory(_currentPlayer);
    }

    public void Logout()
    {
        _currentPlayer = null;
        _currentUser = null;
    }

    public void GainExperience(int amount)
    {
        _currentPlayer.Experience += amount;
        CustomConsole.Info($"Player gains {amount} experience points.");
    }
}
