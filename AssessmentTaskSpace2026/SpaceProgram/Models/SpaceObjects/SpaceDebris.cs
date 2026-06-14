namespace SpaceProgram.Models.SpaceObjects;

using GCommon.Enums;

using static GCommon.Constants.ApplicationConstants;

public class SpaceDebris : SpaceObject
{
    public override SpaceObjectType ObjectType => SpaceObjectType.SpaceDebris;
    
    public override double MovementCost => SpaceDebrisCost;
    
    public override bool IsWalkable => true;
    
    public override string DisplaySymbol => SpaceDebrisSymbol;
}