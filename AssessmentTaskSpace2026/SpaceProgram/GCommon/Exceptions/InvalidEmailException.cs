namespace SpaceProgram.GCommon.Exceptions;

public class InvalidEmailException : EmailInputException
{
    public InvalidEmailException()
    {
    }
    
    public InvalidEmailException(string message)
        : base(message)
    {
    }
}
