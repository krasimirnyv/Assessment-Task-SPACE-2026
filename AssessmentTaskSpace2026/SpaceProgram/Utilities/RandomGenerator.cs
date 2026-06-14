namespace SpaceProgram.Utilities;

using Interfaces;

public class RandomGenerator : IRandomGenerator
{
    private readonly Random _random;
    
    public RandomGenerator()
    {
        _random = new Random();
    }

    public int GenerateIndex(int min, int max)
        => _random.Next(min, max);
    
    public int GenerateAstronautCount(int min, int max)
        => _random.Next(min, max);
}