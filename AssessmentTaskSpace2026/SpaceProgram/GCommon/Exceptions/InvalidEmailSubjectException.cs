namespace SpaceProgram.GCommon.Exceptions;

public class InvalidEmailSubjectException : EmailInputException
{
    public InvalidEmailSubjectException()
    {
    }
    
    public InvalidEmailSubjectException(string message)
        : base(message)
    {
    }
}
