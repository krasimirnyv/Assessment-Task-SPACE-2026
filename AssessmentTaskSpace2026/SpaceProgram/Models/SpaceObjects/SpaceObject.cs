namespace SpaceProgram.Models.SpaceObjects;

using GCommon.Enums;

public abstract class SpaceObject
{
    public abstract SpaceObjectType ObjectType { get; }
    
    public abstract double MovementCost { get; }

    public abstract bool IsWalkable { get; }
    
    public abstract string DisplaySymbol { get; }
}