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
        var gold = SeedItem(new Gold { Name = "Gold", Description = "gold.", Value = 1, Denomination = 1 }, secondLocation.Id);

        // Seed Characters
        var goblin = SeedCharacter(new Enemy { Name = "Goblin", Description = "A small, green creature with sharp teeth.", Health = 20, Damage = 10, Experience = 5, LocationId = startingLocation.Id });
        var dragon = SeedCharacter(new Enemy { Name = "Dragon", Description = "A large, fire-breathing beast.", Health = 100, Damage = 50, Experience = 20, LocationId = secondLocation.Id });

        // Seed User
        var user = SeedUser(new User { Username = "TestUser" });

        // Seed Player
        var player = SeedPlayer(user.Id, new Player { Name = "Player", Description = "This is the player.", Health = 100, Damage = 10, Experience = 0, LocationId = startingLocation.Id, MaxHealth = 100 });

        // Seed Merchants
        var merchant = SeedNpc(new Merchant { Name = "John the Merchant", Inventory = new List<Item> { sword, shield, potion } });

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
            { "drink", ("DrinkPotionCommand", "Execute", new string[] { "potion" }) },
            { "help", ("HelpCommand", "Execute", Array.Empty<string>()) }
        };

        foreach (var command in commands)
        {
            SeedCommand(command.Key, command.Value.ClassName, command.Value.MethodName, command.Value.Parameters);
        }

        // Seed Quests
        var rewardItem = _context.Items.Single(i => i.Name == "Sword");
        var findItemQuest = SeedQuest(new FindItemQuest { Name = "Find Item Quest", Description = "Find a specific item.", Target = "Sword", IsCompleted = false, RewardExperience = 10, RewardGold = 5, LocationId = startingLocation.Id }, new List<Item> { rewardItem });
        var findLocationQuest = SeedQuest(new FindLocationQuest { Name = "Find Location Quest", Description = "Find a specific location.", Target = "Second Location", IsCompleted = false, RewardExperience = 15, RewardGold = 10, LocationId = secondLocation.Id });
        var findNpcQuest = SeedQuest(new FindNpcQuest { Name = "Find NPC Quest", Description = "Find a specific NPC.", Target = "John the Merchant", IsCompleted = false, RewardExperience = 20, RewardGold = 15, LocationId = thirdLocation.Id });
        var killEnemiesQuest = SeedQuest(new KillEnemiesQuest { Name = "Kill Enemies Quest", Description = "Kill a certain number of enemies.", Target = "5", IsCompleted = false, RewardExperience = 25, RewardGold = 20, LocationId = fourthLocation.Id });

        _context.SaveChanges();
    }

    private User SeedUser(User user)
    {
        if (!_context.Users.Any(u => u.Username == user.Username))
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        return user;
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

    private Character SeedPlayer(int userId, Character player)
    {
        if (!_context.Characters.Any(c => c.Name == player.Name))
        {
            var user = _context.Users.Find(userId);
            if (user != null)
            {
                // Initialize the player's Inventory
                player.Inventory = new Inventory();

                _context.Characters.Add(player);
                _context.SaveChanges();

                // Get the player's Inventory
                var inventory = player.Inventory;

                var sword = _context.Items.Single(i => i.Name == "Sword");
                var shield = _context.Items.Single(i => i.Name == "Shield");
                var gold = _context.Items.Single(i => i.Name == "Gold");
                ((Gold)gold).Value = 100;

                // Set the InventoryId property of the items
                sword.InventoryId = inventory.Id;
                shield.InventoryId = inventory.Id;
                gold.InventoryId = inventory.Id;

                inventory.Items.Add(sword);
                inventory.Items.Add(shield);
                inventory.Items.Add(gold);

                _context.SaveChanges();

                user.PlayerId = player.Id;
                _context.SaveChanges();
            }
        }
        return player;
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

    private Quest SeedQuest(Quest quest, List<Item> rewardItems = null)
    {
        if (!_context.Quests.Any(q => q.Name == quest.Name))
        {
            if (rewardItems != null)
            {
                quest.RewardItems = rewardItems;
            }
            _context.Quests.Add(quest);
            _context.SaveChanges();
        }
        return quest;
    }



}