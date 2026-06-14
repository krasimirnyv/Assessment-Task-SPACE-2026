namespace SpaceProgram.Utilities;

using System.Text;

using Interfaces;

public class StringAppender : IStringAppender
{
    private readonly StringBuilder _appender;

    public StringAppender()
    {
        _appender = new StringBuilder();
    }

    public void Append(string? text)
        => _appender.Append(text);

    public void AppendLine()
        => _appender.AppendLine();

    public void AppendLine(string? text)
        => _appender.AppendLine(text);

    public void Clear()
        => _appender.Clear();

    public override string ToString()
        => _appender.ToString();
}