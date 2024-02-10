namespace ConsoleRpg.Entities;

public class DatabaseSeeder
{
    private RpgContext _context;

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
        var sword = SeedItem("Sword", "A sharp blade.", 10, startingLocation.Id);
        var shield = SeedItem("Shield", "A sturdy shield.", 15, secondLocation.Id);

        // Seed Enemies
        var goblin = SeedEnemy("Goblin", "A small, green creature with sharp teeth.", 20, 5, 10, startingLocation.Id);
        var dragon = SeedEnemy("Dragon", "A large, fire-breathing beast.", 100, 20, 50, secondLocation.Id);

        // Seed Quests
        var quest1 = SeedQuest("Quest 1", "This is the first quest.", 100, 50, startingLocation.Id);
        var quest2 = SeedQuest("Quest 2", "This is the second quest.", 200, 100, secondLocation.Id);

        // Seed Merchants
        var merchant = SeedMerchant("John the Merchant");

        // Assign Items to Merchant
        AssignItemToMerchant(sword, merchant.Id);
        AssignItemToMerchant(shield, merchant.Id);

        _context.SaveChanges();
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

    private Item SeedItem(string name, string description, int cost, int locationId)
    {
        if (!_context.Items.Any(i => i.Name == name))
        {
            var item = new Item
            {
                Name = name,
                Description = description,
                Cost = cost,
                LocationId = locationId
            };
            _context.Items.Add(item);
            _context.SaveChanges();
            return item;
        }
        return _context.Items.First(i => i.Name == name);
    }

    private Enemy SeedEnemy(string name, string description, int health, int damage, int experience, int locationId)
    {
        if (!_context.Enemies.Any(e => e.Name == name))
        {
            var enemy = new Enemy
            {
                Name = name,
                Description = description,
                Health = health,
                Damage = damage,
                Experience = experience,
                LocationId = locationId
            };
            _context.Enemies.Add(enemy);
            _context.SaveChanges();
            return enemy;
        }
        return _context.Enemies.First(e => e.Name == name);
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

    private Quest SeedQuest(string name, string description, int rewardExperience, int rewardGold, int locationId)
    {
        if (!_context.Quests.Any(q => q.Name == name))
        {
            var quest = new Quest
            {
                Name = name,
                Description = description,
                RewardExperience = rewardExperience,
                RewardGold = rewardGold,
                LocationId = locationId
            };
            _context.Quests.Add(quest);
            _context.SaveChanges();
            return quest;
        }
        return _context.Quests.First(q => q.Name == name);
    }



    private void AssignItemToMerchant(Item item, int merchantId)
    {
        item.MerchantId = merchantId;
        _context.SaveChanges();
    }
}