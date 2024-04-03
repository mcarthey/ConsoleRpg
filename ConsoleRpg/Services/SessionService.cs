using ConsoleRpg.Dao;
using ConsoleRpg.Entities;
using ConsoleRpg.Models.Characters;

namespace ConsoleRpg.Services;

public class SessionService : ISessionService
{
    private readonly SessionRepository _sessionRepository;
    private readonly IPlayerService _playerService;

    public SessionService(SessionRepository sessionRepository, IPlayerService playerService)
    {
        _sessionRepository = sessionRepository;
        _playerService = playerService;
    }

    public User CurrentUser { get; private set; }
    public Player CurrentPlayer => CurrentUser?.Player;

    public void Login(string username)
    {
        CurrentUser = _sessionRepository.GetUserByUsername(username);
        _playerService.Login(CurrentPlayer);
    }

    public void Logout()
    {
        _playerService.Logout();
    }

}