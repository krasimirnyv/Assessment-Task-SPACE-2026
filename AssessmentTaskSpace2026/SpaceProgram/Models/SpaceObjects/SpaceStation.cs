namespace SpaceProgram.Models.SpaceObjects;

using GCommon.Enums;

using static GCommon.Constants.ApplicationConstants;

public class SpaceStation : SpaceObject
{
    public override SpaceObjectType ObjectType => SpaceObjectType.SpaceStation;
    
    public override double MovementCost => SpaceStationCost;
    
    public override bool IsWalkable => true;

    public override string DisplaySymbol => SpaceStationSymbol;
}