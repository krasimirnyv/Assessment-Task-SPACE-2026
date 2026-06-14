namespace SpaceProgram.IO;

using Interfaces;

public class ConsoleWriter : IWriter
{ 
    public void Clear() 
        => Console.Clear();
    
    public void Write(string? line) 
        => Console.Write(line);
    
    public void WriteLine() 
        => Console.WriteLine();

    public void WriteLine(string? line) 
        => Console.WriteLine(line);
    
}
