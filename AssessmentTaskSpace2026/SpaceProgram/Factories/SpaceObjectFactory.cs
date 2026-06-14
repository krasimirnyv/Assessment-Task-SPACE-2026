namespace SpaceProgram.Factories;


using Interfaces;
using Models.SpaceObjects;
using GCommon.Enums;
using GCommon.Exceptions;

using static GCommon.Constants.Messages;

public class SpaceObjectFactory : ISpaceObjectFactory
{
    public SpaceObject CreateSpaceObject(SpaceObjectType objectType)
    {
        return objectType switch
        {
            SpaceObjectType.SpaceStation => new SpaceStation(), 
            SpaceObjectType.Asteroid => new Asteroid(),
            SpaceObjectType.SpaceDebris => new SpaceDebris(),
            SpaceObjectType.OpenSpace => new OpenSpace(),
            _ => throw new InvalidSpaceObjectException(string.Format(InvalidSpaceObjectMessage, objectType))
        };
    }

    public Astronaut CreateAstronaut(string name) => new(name);
}
