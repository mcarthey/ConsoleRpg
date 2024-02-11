using Spectre.Console;

public static class CustomConsole
{
    public static void Info(string message)
    {
        AnsiConsole.MarkupLine($"[green]{message}[/]");
    }

    public static void Warn(string message)
    {
        AnsiConsole.MarkupLine($"[yellow]{message}[/]");
    }

    public static void Error(string message)
    {
        AnsiConsole.MarkupLine($"[red]{message}[/]");
    }

    public static void Notice(string message)
    {
        AnsiConsole.MarkupLine($"[cyan]{message}[/]");
    }

    public static void Highlight(string message)
    {
        AnsiConsole.MarkupLine($"[magenta]{message}[/]");
    }

    public static void Prompt(string message)
    {
        AnsiConsole.MarkupLine($"[white]{message}[/]");
    }

    public static void Result(string message)
    {
        AnsiConsole.MarkupLine($"[blue]{message}[/]");
    }
}
