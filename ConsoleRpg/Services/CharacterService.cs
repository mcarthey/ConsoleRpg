using ConsoleRpg.Entities;
using ConsoleRpg.Models.Items.Effects;
using ConsoleRpg.Dao;
using System.Collections.Generic;

public class CharacterService
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
}
