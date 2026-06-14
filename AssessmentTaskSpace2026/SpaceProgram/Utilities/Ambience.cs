namespace SpaceProgram.Utilities;

using Interfaces;

public class Ambience : IAmbience
{
    public void Exit() 
        => Environment.Exit(0);
}