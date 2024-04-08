using ConsoleRpg.Dao;
using ConsoleRpg.Entities;

namespace ConsoleRpg.Services;

public class CharacterService : ICharacterService
{
    private readonly CharacterRepository _characterRepository;

    public CharacterService(CharacterRepository characterRepository)
    {
        _characterRepository = characterRepository;
    }

    public Character GetCharacter(int characterId)
    {
        return _characterRepository.GetCharacter(characterId);
    }

    public void SaveCharacter(Character character)
    {
        _characterRepository.SaveChanges();
    }

    public void GainExperience(Character character, int amount)
    {
        character.Experience += amount;
        _characterRepository.SaveChanges();
    }
}