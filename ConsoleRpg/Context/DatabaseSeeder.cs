using ConsoleRpg.Entities;
using ConsoleRpg.Models.Characters;
using ConsoleRpg.Models.Items;
using ConsoleRpg.Models.Items.Effects;
using ConsoleRpg.Models.Npcs;
using ConsoleRpg.Models.Quests;

namespace ConsoleRpg.Context;

public class DatabaseSeeder
{
    private readonly RpgContext _context;

    public DatabaseSeeder(RpgContext context)
    {
        _context = context;
    }

    public void SeedDatabase()
    {
        // Seed Locations
        var startingLocation = SeedLocation("Starting Location", "This is where the player starts the game.");
        var secondLocation = SeedLocation("Second Location", "This is the second location.");
        var thirdLocation = SeedLocation("Third Location", "This is the third location.");
        var fourthLocation = SeedLocation("Fourth Location", "This is the fourth location.");

        // Seed Items
        var sword = (Sword)SeedItem(new Sword { Name = "Sword", Description = "A sharp blade.", Damage = 10, Durability = 100, Price = 15 }, startingLocation.Id);
        var shield = (Shield)SeedItem(new Shield { Name = "Shield", Description = "A sturdy shield.", Defense = 15, Durability = 100, Price = 10 }, secondLocation.Id);
        var potion = SeedItem(new Potion { Name = "Potion", Description = "A healing potion.", Duration = 5, Color = "Red", Effects = new List<Effect> { new HealEffect { Value = 1 } } }, startingLocation.Id);
        var gold = SeedItem(new Gold { Name = "Gold", Description = "A gold coin.", Amount = 1, Denomination = 1 }, secondLocation.Id);

        // Seed Characters
        var goblin = SeedCharacter(new Enemy { Name = "Goblin", Description = "A small, green creature with sharp teeth.", Health = 20, Damage = 10, Experience = 5, LocationId = startingLocation.Id });
        var dragon = SeedCharacter(new Enemy { Name = "Dragon", Description = "A large, fire-breathing beast.", Health = 100, Damage = 50, Experience = 20, LocationId = secondLocation.Id });

        // Seed Merchants
        var merchant = SeedNpc(new Merchant { Name = "John the Merchant", Inventory = new List<Item> { sword, shield } });

        // Seed Commands
        var commands = new Dictionary<string, (string ClassName, string MethodName, string[] Parameters)>
        {
            { "move", ("MoveToLocationCommand", "Execute", new string[] { "locationName" }) },
            { "check", ("CheckInventoryCommand", "Execute", Array.Empty<string>()) },
            { "attack", ("AttackEnemiesCommand", "Execute", new string[] { "location" }) },
            { "visit", ("VisitMerchantCommand", "Execute", Array.Empty<string>()) },
            { "view", ("ViewCurrentQuestsCommand", "Execute", Array.Empty<string>()) },
            { "pick", ("PickUpQuestCommand", "Execute", new string[] { "quest" }) },
            { "quit", ("SavePlayerAndQuitCommand", "Execute", Array.Empty<string>()) },
            { "help", ("HelpCommand", "Execute", Array.Empty<string>()) }
        };

        foreach (var command in commands)
        {
            SeedCommand(command.Key, command.Value.ClassName, command.Value.MethodName, command.Value.Parameters);
        }

        // Seed Quests
        var findItemQuest = SeedQuest(new FindItemQuest { Name = "Find Item Quest", Description = "Find a specific item.", Target = "Sword", IsCompleted = false, RewardExperience = 10, RewardGold = 5, LocationId = startingLocation.Id });
        var findLocationQuest = SeedQuest(new FindLocationQuest { Name = "Find Location Quest", Description = "Find a specific location.", Target = "Second Location", IsCompleted = false, RewardExperience = 15, RewardGold = 10, LocationId = secondLocation.Id });
        var findNpcQuest = SeedQuest(new FindNpcQuest { Name = "Find NPC Quest", Description = "Find a specific NPC.", Target = "John the Merchant", IsCompleted = false, RewardExperience = 20, RewardGold = 15, LocationId = thirdLocation.Id });
        var killEnemiesQuest = SeedQuest(new KillEnemiesQuest { Name = "Kill Enemies Quest", Description = "Kill a certain number of enemies.", Target = "5", IsCompleted = false, RewardExperience = 25, RewardGold = 20, LocationId = fourthLocation.Id });

        _context.SaveChanges();
    }

    private Location SeedLocation(string name, string description)
    {
        var location = _context.Locations.FirstOrDefault(l => l.Name == name);
        if (location == null)
        {  
            location = new Location { Name = name, Description = description };
            _context.Locations.Add(location);
            _context.SaveChanges();
        }
        return location;
    }

    private Item SeedItem(Item item, int locationId)
    {
        if (!_context.Items.Any(i => i.Name == item.Name))
        {
            item.LocationId = locationId;
            _context.Items.Add(item);
            _context.SaveChanges();
        }
        return item;
    }

    private Character SeedCharacter(Character character)
    {
        if (!_context.Characters.Any(c => c.Name == character.Name))
        {
            _context.Characters.Add(character);
            _context.SaveChanges();
        }
        return character;
    }

    private Npc SeedNpc(Npc npc)
    {
        if (!_context.Npcs.Any(n => n.Name == npc.Name))
        {
            _context.Npcs.Add(npc);
            _context.SaveChanges();
        }
        return npc;
    }

    private void SeedCommand(string name, string className, string action, string[] parameters)
    {
        if (!_context.Commands.Any(c => c.Name == name))
        {
            var command = new Command
            {
                Name = name,
                ClassName = className,
                Action = action,
                Parameters = parameters
            };
            _context.Commands.Add(command);
            _context.SaveChanges();
        }
    }

    private Quest SeedQuest(Quest quest)
    {
        if (!_context.Quests.Any(q => q.Name == quest.Name))
        {
            _context.Quests.Add(quest);
            _context.SaveChanges();
        }
        return quest;
    }


}