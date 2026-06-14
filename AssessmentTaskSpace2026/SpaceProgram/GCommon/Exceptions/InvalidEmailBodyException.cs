namespace SpaceProgram.GCommon.Exceptions;

public class InvalidEmailBodyException : EmailInputException
{
    public InvalidEmailBodyException()
    {
    }
    
    public InvalidEmailBodyException(string message)
        : base(message)
    {
    }
}
