namespace SpaceProgram.GCommon.Exceptions;

public class NullInputException : Exception
{
    public NullInputException()
    {
    }

    public NullInputException(string message)
        : base(message)
    {
    }
}
