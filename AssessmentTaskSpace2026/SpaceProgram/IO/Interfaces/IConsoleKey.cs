namespace SpaceProgram.IO.Interfaces;

using Enums;

public interface IConsoleKey
{
    UserCommand ReadRestartKey();

    UserCommand ReadEmailKey();
}