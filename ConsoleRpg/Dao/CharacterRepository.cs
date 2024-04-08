using ConsoleRpg.Context;
using ConsoleRpg.Entities;

namespace ConsoleRpg.Dao;

public class CharacterRepository
{
    private readonly RpgContext _context;

    public CharacterRepository(RpgContext context)
    {
        _context = context;
    }

    public Character GetCharacter(int characterId)
    {
        return _context.Characters.Find(characterId);
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}