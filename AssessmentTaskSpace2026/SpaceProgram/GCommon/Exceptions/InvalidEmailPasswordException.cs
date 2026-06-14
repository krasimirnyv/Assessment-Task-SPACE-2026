namespace SpaceProgram.GCommon.Exceptions;

public class InvalidEmailPasswordException : EmailInputException
{
    public InvalidEmailPasswordException()
    {
    }
    
    public InvalidEmailPasswordException(string message)
        : base(message)
    {
    }
}
