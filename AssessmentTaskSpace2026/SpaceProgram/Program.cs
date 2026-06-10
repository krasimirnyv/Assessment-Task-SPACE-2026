namespace SpaceProgram;

using IO;
using IO.Interfaces;

public class Program
{
    public static void Main()
    {
        IWriter writer = new ConsoleWriter();
        IReader reader = new ConsoleReader();
    }
}