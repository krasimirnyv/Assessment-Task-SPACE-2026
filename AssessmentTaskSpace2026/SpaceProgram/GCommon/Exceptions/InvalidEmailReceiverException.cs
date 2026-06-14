namespace SpaceProgram.GCommon.Exceptions;

public class InvalidEmailReceiverException : EmailInputException
{
    public InvalidEmailReceiverException()
    {
    }
    
    public InvalidEmailReceiverException(string message)
        : base(message)
    {
    }
}
