namespace SpaceProgram.IO;

using Interfaces;
using Enums;

public class ConsoleKey : IConsoleKey
{
    public UserCommand ReadRestartKey()
    {
        ConsoleKeyInfo keyInfo = Console.ReadKey(true);

        return keyInfo.Key == System.ConsoleKey.Tab
                            ? UserCommand.Exit
                            : UserCommand.Restart;
    }
    
    public UserCommand ReadEmailKey()
    {
        ConsoleKeyInfo keyInfo = Console.ReadKey(true);

        return keyInfo.Key == System.ConsoleKey.Y
            ? UserCommand.Yes
            : UserCommand.No;
    }
}
