namespace SpaceProgram.GCommon.Validations;

using Exceptions;

using static Constants.Messages;
using static Constants.ApplicationConstants;

public static class DimensionValidator
{
    public static int ValidateDimension(string? input, string dimensionName)
    {
        if (string.IsNullOrWhiteSpace(input))
            throw new NullInputException(string.Format(NullMapDimensionMessage, dimensionName, MinSize, MaxSize));

        bool isValidNumber = int.TryParse(input, out int value);
        if (!isValidNumber || value is < MinSize or > MaxSize)
            throw new InvalidInputException(string.Format(InvalidMapDimensionMessage, dimensionName, MinSize, MaxSize));

        return value;
    }
}