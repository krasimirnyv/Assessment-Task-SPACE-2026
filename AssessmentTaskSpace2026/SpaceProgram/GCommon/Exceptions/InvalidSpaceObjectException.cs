namespace SpaceProgram.GCommon.Exceptions;

public class InvalidSpaceObjectException : Exception
{
    public InvalidSpaceObjectException()
    {
    }

    public InvalidSpaceObjectException(string message)
        : base(message)
    {
    }
}
