namespace ConsoleRpg.Entities;

public class Command
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Action { get; set; } = string.Empty;
    public string ClassName { get; set; } = string.Empty;
    public string[] Parameters { get; set; } = Array.Empty<string>();
}

