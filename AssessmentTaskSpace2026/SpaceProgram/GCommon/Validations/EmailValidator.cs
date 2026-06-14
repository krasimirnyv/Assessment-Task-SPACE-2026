namespace SpaceProgram.GCommon.Validations;

using System.Text.RegularExpressions;

using Exceptions;

using static Constants.Messages;
using static Constants.ApplicationConstants;

public static class EmailValidator
{
    public static void ValidateSenderEmail(string? email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new NullInputException(NullEmailMessage);

        if (!IsValidEmail(email))
            throw new InvalidEmailReceiverException(InvalidEmailSenderMessage);
    }

    public static void ValidateAppPassword(string? password)
    {
        if (string.IsNullOrWhiteSpace(password) 
            || password.Length < GmailAppPasswordMinLength
            || password.Length > GmailAppPasswordMaxLength)
            throw new InvalidEmailPasswordException(InvalidPasswordMessage);
    }

    public static void ValidateReceiverEmail(string? email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new NullInputException(NullEmailMessage);

        if (!IsValidEmail(email))
            throw new InvalidEmailReceiverException(InvalidEmailReceiverMessage);
    }

    public static void ValidateSubject(string? subject)
    {
        if (string.IsNullOrWhiteSpace(subject))
            throw new InvalidEmailSubjectException(InvalidEmailSubjectMessage);
    }

    public static void ValidateBody(string? body)
    {
        if (string.IsNullOrWhiteSpace(body))
            throw new InvalidEmailBodyException(InvalidEmailBodyMessage);
    }

    private static bool IsValidEmail(string email)
        => Regex.IsMatch(email, @"^[a-zA-Z0-9](?:[a-zA-Z0-9._]*[a-zA-Z0-9])?@gmail\.com$");
}