using SpaceProgram.IO.Interfaces;

namespace SpaceProgram.IO;

public class ConsoleWriter : IWriter
{ 
    public void WriteLine(string line) => Console.WriteLine(line);
}