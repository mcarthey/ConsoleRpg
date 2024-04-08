using ConsoleRpg.Entities;

namespace ConsoleRpg.Services;

public interface ICharacterService
{
    public Character GetCharacter(int characterId);

    public void SaveCharacter(Character character);

    public void GainExperience(Character character, int amount);
}