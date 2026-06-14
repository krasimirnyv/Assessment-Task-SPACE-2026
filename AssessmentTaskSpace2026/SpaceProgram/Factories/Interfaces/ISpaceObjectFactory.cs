namespace SpaceProgram.Factories.Interfaces;

using Models.SpaceObjects;
using GCommon.Enums;

public interface ISpaceObjectFactory
{
    SpaceObject CreateSpaceObject(SpaceObjectType objectType);

    Astronaut CreateAstronaut(string name);
}