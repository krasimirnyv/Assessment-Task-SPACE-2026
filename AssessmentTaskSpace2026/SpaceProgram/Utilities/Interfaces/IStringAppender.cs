namespace SpaceProgram.Utilities.Interfaces;

public interface IStringAppender
{
    void Append(string? text);
    
    void AppendLine();

    void AppendLine(string? text);

    void Clear();

    string ToString();
}