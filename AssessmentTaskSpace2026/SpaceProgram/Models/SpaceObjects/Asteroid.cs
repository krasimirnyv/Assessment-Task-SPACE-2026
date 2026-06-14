namespace SpaceProgram.Models.SpaceObjects;

using GCommon.Enums;

using static GCommon.Constants.ApplicationConstants;

public class Asteroid : SpaceObject
{
    public override SpaceObjectType ObjectType => SpaceObjectType.Asteroid;

    public override double MovementCost => double.PositiveInfinity;

    public override bool IsWalkable => false;

    public override string DisplaySymbol => AsteroidSymbol;
}