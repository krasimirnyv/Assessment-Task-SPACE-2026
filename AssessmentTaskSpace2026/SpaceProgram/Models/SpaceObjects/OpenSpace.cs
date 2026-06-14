namespace SpaceProgram.Models.SpaceObjects;

using GCommon.Enums;

using static GCommon.Constants.ApplicationConstants;

public class OpenSpace : SpaceObject
{
    public override SpaceObjectType ObjectType => SpaceObjectType.OpenSpace;

    public override double MovementCost => OpenSpaceCost;
    
    public override bool IsWalkable => true;

    public override string DisplaySymbol => OpenSpaceSymbol;
}