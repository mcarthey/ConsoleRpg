namespace ConsoleRpg.Commands;

public interface ICommand
{
    void Execute(string[] parameters);
}