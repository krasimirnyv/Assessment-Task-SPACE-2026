namespace SpaceProgram.Models.SpaceObjects;

using GCommon.Enums;

using static GCommon.Constants.ApplicationConstants;

public class Astronaut : SpaceObject
{
    public Astronaut(string name)
    {
        Name = name;
    }

    private string Name { get; }
    
    public override SpaceObjectType ObjectType => SpaceObjectType.Astronaut;

    public override double MovementCost => AstronautCost;

    public override bool IsWalkable => true;

    public override string DisplaySymbol => Name;
}