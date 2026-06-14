namespace SpaceProgram.Utilities.Interfaces;

using static GCommon.Constants.ApplicationConstants;

public interface IRandomGenerator
{
    int GenerateIndex(int min, int max);

    int GenerateAstronautCount(int min = MinimumAmountOfAstronauts, int max = MaximumAmountOfAstronauts);
}