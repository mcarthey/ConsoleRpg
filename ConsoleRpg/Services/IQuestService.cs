using ConsoleRpg.Entities;

public interface IQuestService
{
    void AddQuest(Quest quest);
    void ShowActiveQuests();
    void CompleteQuest(Quest quest);
    List<Quest> GetActiveQuests();
    Quest? GetQuestByName(string questName);
    void PickUpQuest(Quest quest);
}
