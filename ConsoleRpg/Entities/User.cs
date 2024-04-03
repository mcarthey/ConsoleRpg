using ConsoleRpg.Models.Characters;

namespace ConsoleRpg.Entities;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public int PlayerId { get; set; }
    public virtual Player Player { get; set; }
}