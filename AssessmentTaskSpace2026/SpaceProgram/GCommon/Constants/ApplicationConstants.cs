namespace SpaceProgram.GCommon.Constants;

public static class ApplicationConstants
{
    // Map 
    public const int MinSize = 2;
    public const int MaxSize = 100;

    public const string RowName = "rows";
    public const string ColumnName = "columns";
    
    public const string PluralStepsSuffix = "s";
    
    // Symbols
    public const string SpaceStationSymbol = "F";
    public const string AstronautSymbol = "S";
    public const string AsteroidSymbol = "X";
    public const string OpenSpaceSymbol = "O";
    public const string SpaceDebrisSymbol = "D";
    public const string JourneySymbol = "*";
    public const string MissingSymbol = "?";
    
    // Amount of astronauts
    public const int MinimumAmountOfAstronauts = 1;
    public const int MaximumAmountOfAstronauts = 4;
    
    // Movement cost
    public const double OpenSpaceCost = 1;
    public const double SpaceStationCost = 1;
    public const double AstronautCost = 1;
    public const double SpaceDebrisCost = 2;
    
    // Print
    public const int CellWidth = 3;
    
    // Email
    public const string GmailSmtpHost = "smtp.gmail.com";
    public const int GmailSmtpPort = 587;
    public const bool GmailEnableSsl = true;
    public const bool GmailUseDefaultCredentials = false;
    
    public const int GmailAppPasswordMinLength = 16;
    public const int GmailAppPasswordMaxLength = 19;
}