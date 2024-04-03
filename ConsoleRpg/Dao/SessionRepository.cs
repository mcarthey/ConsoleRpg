using ConsoleRpg.Context;
using ConsoleRpg.Entities;
using ConsoleRpg.Models.Characters;
using Microsoft.EntityFrameworkCore;

namespace ConsoleRpg.Dao;

public class SessionRepository
{
    private readonly RpgContext _context;

    public SessionRepository(RpgContext context)
    {
        _context = context;
    }

    public User GetUserByUsername(string username)
    {
        return _context.Users.Include(u => u.Player).FirstOrDefault(u => u.Username == username);
    }

    public Player GetPlayerByUserId(int userId)
    {
        return _context.Characters.OfType<Player>().FirstOrDefault(p => p.User.Id == userId);
    }

    public Player GetPlayerByUsername(string username)
    {
        return _context.Characters.OfType<Player>().FirstOrDefault(p => p.User.Username == username);
    }

    public void UpdatePlayer(Player currentPlayer)
    {
        throw new NotImplementedException();
    }
}
