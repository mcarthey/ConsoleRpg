using ConsoleRpg.Entities;
using ConsoleRpg.Models.Characters;
using ConsoleRpg.Models.Items;
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

        // Seed Exits
        SeedExit("north", startingLocation.Id, secondLocation.Id);
        SeedExit("south", secondLocation.Id, startingLocation.Id);

        // Seed Items
        var sword = SeedSword("Sword", "A sharp blade.", 10, 15, startingLocation.Id);
        var shield = SeedShield("Shield", "A sturdy shield.", 15, 10, secondLocation.Id);
        var potion = SeedPotion("Potion", "A healing potion.", 5, 20, startingLocation.Id);
        var gold = SeedGold("Gold", "A gold coin.", 1, 1, secondLocation.Id);
        var generalItem = SeedGeneralItem("General Item", "A general item.", 2, startingLocation.Id);

        // Seed Enemies
        var goblin = SeedEnemy("Goblin", "A small, green creature with sharp teeth.", 20, 5, 10, startingLocation.Id);
        var dragon = SeedEnemy("Dragon", "A large, fire-breathing beast.", 100, 20, 50, secondLocation.Id);

        // Seed Merchants
        var merchant = SeedMerchant("John the Merchant");

        // Assign Items to Merchant
        AssignItemToMerchant(sword, merchant.Id);
        AssignItemToMerchant(shield, merchant.Id);

        // Seed NPCs
        var npc1 = SeedNpc("Bob the Builder");
        var npc2 = SeedNpc("Alice the Alchemist");

        // Seed DialogueOptions
        SeedDialogueOption("Hello, adventurer!", npc1.Id);
        SeedDialogueOption("I have a quest for you.", npc1.Id);
        SeedDialogueOption("Welcome to my shop!", npc2.Id);
        SeedDialogueOption("I can make potions for you.", npc2.Id);

        // Seed Quests
        var quest1 = SeedQuest("Kill Goblins", "Kill 10 goblins.", 100, 50, startingLocation.Id, npc1.Id, "KillEnemies", "10");
        var quest2 = SeedQuest("Find Sword", "Find the legendary sword.", 200, 100, secondLocation.Id, npc2.Id, "FindItem", "Sword");
        var quest3 = SeedQuest("Find Alice", "Find Alice the Alchemist.", 100, 50, startingLocation.Id, npc1.Id, "FindNpc", "Alice the Alchemist");
        var quest4 = SeedQuest("Find Second Location", "Find the second location.", 200, 100, secondLocation.Id, npc2.Id, "FindLocation", "Second Location");

        // Seed LootTables
        var goblinLootTable = SeedLootTable(new List<Item> { sword }, goblin);
        var dragonLootTable = SeedLootTable(new List<Item> { shield }, dragon);

        // Assign LootTables to Enemies
        goblin.LootTableId = goblinLootTable.Id;
        dragon.LootTableId = dragonLootTable.Id;

        // Seed Commands
        var commands = new Dictionary<string, (string ClassName, string MethodName, string[] Parameters)>
        {
            { "move", ("MoveToLocationCommand", "Execute", new string[] { "locationName" }) },
            { "check", ("CheckInventoryCommand", "Execute", Array.Empty<string>()) },
            { "attack", ("AttackEnemiesCommand", "Execute", new string[] { "location" }) },
            { "visit", ("DisplayVisitMessageCommand", "Execute", Array.Empty<string>()) },
            { "view", ("ViewCurrentQuestsCommand", "Execute", Array.Empty<string>()) },
            { "pick", ("PickUpQuestCommand", "Execute", new string[] { "quest" }) },
            { "quit", ("SavePlayerAndQuitCommand", "Execute", Array.Empty<string>()) },
            { "help", ("HelpCommand", "Execute", Array.Empty<string>()) }
        };

        foreach (var command in commands)
        {
            SeedCommand(command.Key, command.Value.ClassName, command.Value.MethodName, command.Value.Parameters);
        }

        _context.SaveChanges();
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
        }
    }


    private Sword SeedSword(string name, string description, int cost, int damage, int locationId)
    {
        var sword = new Sword
        {
            Name = name,
            Description = description,
            Cost = cost,
            Damage = damage,
            LocationId = locationId
        };
        _context.Items.Add(sword);
        _context.SaveChanges();
        return sword;
    }

    private LootTable SeedLootTable(List<Item> items, Enemy enemy)
    {
        var enemyId = enemy.Id;
        LootTable lootTable;

        if (_context.LootTables.Any(lt => lt.EnemyId == enemyId))
        {
            // LootTable already exists for this Enemy, update it
            lootTable = _context.LootTables.First(lt => lt.EnemyId == enemyId);
            lootTable.Items.Clear(); // Clear existing items before adding new ones
        }
        else
        {
            // LootTable does not exist for this Enemy, create it
            lootTable = new LootTable { EnemyId = enemyId };
            _context.LootTables.Add(lootTable);
        }

        foreach (var item in items)
        {
            lootTable.Items.Add(item);
        }

        _context.SaveChanges();
        return lootTable;
    }


    private Npc SeedNpc(string name)
    {
        if (!_context.Npcs.Any(n => n.Name == name))
        {
            var npc = new Npc
            {
                Name = name
            };
            _context.Npcs.Add(npc);
            _context.SaveChanges();
            return npc;
        }

        return _context.Npcs.First(n => n.Name == name);
    }

    private void SeedDialogueOption(string text, int npcId)
    {
        if (!_context.DialogueOptions.Any(d => d.Text == text && d.NpcId == npcId))
        {
            var dialogueOption = new DialogueOption
            {
                Text = text,
                NpcId = npcId
            };
            _context.DialogueOptions.Add(dialogueOption);
            _context.SaveChanges();
        }
    }

    private void AssignItemToMerchant(Item item, int merchantId)
    {
        item.MerchantId = merchantId;
        _context.SaveChanges();
    }

    private Enemy SeedEnemy(string name, string description, int health, int damage, int experience, int locationId, int? questId = null)
    {
        if (!_context.Enemies.Any(e => e.Name == name))
        {
            var enemy = new Enemy
            {
                Name = name,
                Description = description,
                Health = health,
                MaxHealth = health,
                Damage = damage,
                Experience = experience,
                LocationId = locationId,
                QuestId = questId
            };
            _context.Enemies.Add(enemy);
            _context.SaveChanges();
            return enemy;
        }

        return _context.Enemies.First(e => e.Name == name);
    }

    private void SeedExit(string direction, int locationId, int destinationLocationId)
    {
        if (!_context.Exits.Any(e => e.Direction == direction && e.LocationId == locationId))
        {
            var exit = new Exit
            {
                Direction = direction,
                LocationId = locationId,
                DestinationLocationId = destinationLocationId
            };
            _context.Exits.Add(exit);
            _context.SaveChanges();
        }
    }

    private Shield SeedShield(string name, string description, int cost, int defense, int locationId)
    {
        var shield = new Shield
        {
            Name = name,
            Description = description,
            Cost = cost,
            Defense = defense,
            LocationId = locationId
        };
        _context.Items.Add(shield);
        _context.SaveChanges();
        return shield;
    }

    private Potion SeedPotion(string name, string description, int cost, int healing, int locationId)
    {
        var potion = new Potion
        {
            Name = name,
            Description = description,
            Cost = cost,
            Healing = healing,
            LocationId = locationId
        };
        _context.Items.Add(potion);
        _context.SaveChanges();
        return potion;
    }

    private Gold SeedGold(string name, string description, int cost, int amount, int locationId)
    {
        var gold = new Gold
        {
            Name = name,
            Description = description,
            Cost = cost,
            Amount = amount,
            LocationId = locationId
        };
        _context.Items.Add(gold);
        _context.SaveChanges();
        return gold;
    }

    private GeneralItem SeedGeneralItem(string name, string description, int cost, int locationId)
    {
        var generalItem = new GeneralItem
        {
            Name = name,
            Description = description,
            Cost = cost,
            LocationId = locationId
        };
        _context.Items.Add(generalItem);
        _context.SaveChanges();
        return generalItem;
    }


    private Location SeedLocation(string name, string description)
    {
        if (!_context.Locations.Any(l => l.Name == name))
        {
            var location = new Location
            {
                Name = name,
                Description = description
            };
            _context.Locations.Add(location);
            _context.SaveChanges();
            return location;
        }

        return _context.Locations.First(l => l.Name == name);
    }

    private Merchant SeedMerchant(string name)
    {
        if (!_context.Merchants.Any(m => m.Name == name))
        {
            var merchant = new Merchant
            {
                Name = name
            };
            _context.Merchants.Add(merchant);
            _context.SaveChanges();
            return merchant;
        }

        return _context.Merchants.First(m => m.Name == name);
    }

    private Quest? SeedQuest(string name, string description, int rewardExperience, int rewardGold, int locationId, int npcId, string questType, string questTarget)
    {
        Quest? quest = null;

        switch (questType)
        {
            case "KillEnemies":
                quest = _context.KillEnemiesQuests.FirstOrDefault(q => q.Name == name);
                if (quest == null)
                {
                    quest = new KillEnemiesQuest
                    {
                        Name = name,
                        Description = description,
                        RewardExperience = rewardExperience,
                        RewardGold = rewardGold,
                        LocationId = locationId,
                        NpcId = npcId,
                        Target = questTarget
                    };
                    _context.KillEnemiesQuests.Add((KillEnemiesQuest)quest);
                }
                break;
            case "FindLocation":
                quest = _context.FindLocationQuests.FirstOrDefault(q => q.Name == name);
                if (quest == null)
                {
                    quest = new FindLocationQuest
                    {
                        Name = name,
                        Description = description,
                        RewardExperience = rewardExperience,
                        RewardGold = rewardGold,
                        LocationId = locationId,
                        NpcId = npcId,
                        Target = questTarget
                    };
                    _context.FindLocationQuests.Add((FindLocationQuest)quest);
                }
                break;
            case "FindItem":
                quest = _context.FindItemQuests.FirstOrDefault(q => q.Name == name);
                if (quest == null)
                {
                    quest = new FindItemQuest
                    {
                        Name = name,
                        Description = description,
                        RewardExperience = rewardExperience,
                        RewardGold = rewardGold,
                        LocationId = locationId,
                        NpcId = npcId,
                        Target = questTarget
                    };
                    _context.FindItemQuests.Add((FindItemQuest)quest);
                }
                break;
            case "FindNpc":
                quest = _context.FindNpcQuests.FirstOrDefault(q => q.Name == name);
                if (quest == null)
                {
                    quest = new FindNpcQuest
                    {
                        Name = name,
                        Description = description,
                        RewardExperience = rewardExperience,
                        RewardGold = rewardGold,
                        LocationId = locationId,
                        NpcId = npcId,
                        Target = questTarget
                    };
                    _context.FindNpcQuests.Add((FindNpcQuest)quest);
                }
                break;
        }

        _context.SaveChanges();

        return quest;
    }
}
