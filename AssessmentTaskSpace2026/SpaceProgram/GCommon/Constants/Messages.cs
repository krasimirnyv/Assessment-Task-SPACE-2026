namespace SpaceProgram.GCommon.Constants;

public static class Messages
{
    // Map & Dimensions
    public const string WelcomeMessage = "Welcome to the Space Program!";
    public const string MapPrompt = "Please enter the map's {0}: ";
    public const string InvalidMapDimensionMessage = "Invalid map's {0} dimensions. Please enter positive integer betweem {1} and {2}.";
    public const string NullMapDimensionMessage = "Map's {0} can not be null, empty or whitespace. Please enter positive integer betweem {1} and {2}.";
    public const string SomethingWrongWithMapMessage = "Something went wrong. Please try entering a valid value between {0} and {1} again.";
    public const string ReadyToUseMapMessage = "\tCosmic map:\n";

    // Completed mission
    public const string MissionSucceededMessage = "\tAstronaut {0} — Shortest path: {1} step{2}.\n";
    
    // Failed mission
    public const string MissionFailedMessage = "\tMission failed — Astronaut {0} lost in space!\n";
    
    // Email
    public const string WantEmailMessage = "Do you want to send the report via email? - Y / any key: ";
    public const string WriteYourEmailMessage = "Your email: ";
    public const string WriteYourPasswordMessage = "Your Gmail App Password: ";
    public const string WriteEmailReceiverMessage = "Send it to email: ";
    public const string EmailSubjectMessage = "Subject: ";
    public const string EmailSendSuccessMessage = "Email sent successfully.";
    
    // Invalid email
    public const string NullEmailMessage = "Email adresses cannot be null, empty or whitespace. Please provide a valid email address.";
    public const string InvalidEmailSenderMessage = "Your email address is invalid. Please provide a valid email address.";
    public const string InvalidPasswordMessage = "Your Gmail App Password is invalid. Please provide a valid application password.";
    public const string InvalidEmailReceiverMessage = "Invalid receiver email address. Please provide a valid email address.";
    public const string InvalidEmailSubjectMessage = "Invalid email subject. Subject cannot be null, empty or whitespace.";
    public const string InvalidEmailBodyMessage = "The email body cannot be empty.";
    public const string EmailWentWrongMessage = "Email was not sent due to an error.";
    public const string EmailSendingFailedMessage = "Could not send the e-mail. Please check your email, app password, receiver address and internet connection.";
    
    // Game ending
    public const string TryNewGameMessage = "Press [TAB] to exit or any other key to RESTART...";
    public const string QuitMessage = "Goodbye :)";
    
    // Other
    public const string InvalidSpaceObjectMessage = "Invalid symbol: {0}";
}
