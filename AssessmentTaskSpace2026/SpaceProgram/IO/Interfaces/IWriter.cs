namespace SpaceProgram.IO.Interfaces;

public interface IWriter
{
    void Clear();
    
    void Write(string? line);
    
    void WriteLine();

    void WriteLine(string? line);
}