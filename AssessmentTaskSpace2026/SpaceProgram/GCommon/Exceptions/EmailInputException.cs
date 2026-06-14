namespace SpaceProgram.GCommon.Exceptions;

public abstract class EmailInputException : Exception
{
    protected EmailInputException()
    {
    }
    
    protected EmailInputException(string message)
        : base(message)
    {
    }
}
