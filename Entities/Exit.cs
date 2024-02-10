namespace ConsoleRpg.Entities;

public class Exit
{
    public int Id { get; set; }
    public string Direction { get; set; }
    public int LocationId { get; set; } // Foreign key property
    public virtual Location Location { get; set; } // Navigation property

}