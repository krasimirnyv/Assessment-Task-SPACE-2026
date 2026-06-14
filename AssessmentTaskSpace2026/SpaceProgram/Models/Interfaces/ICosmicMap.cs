namespace SpaceProgram.Models.Interfaces;

using SpaceObjects;

public interface ICosmicMap
{
    int Rows { get; }

    int Columns { get; }

    Coordinates SpaceStationCoordinates { get; }

    ICollection<Coordinates> AstronautsCoordinates { get; }

    IEnumerable<Coordinates> GetWalkableNeighbours(Coordinates coordinates);

    ICollection<Coordinates> GetAllCoordinates();

    SpaceObject GetObjectAt(Coordinates coordinates);
    
    bool TryGetObjectAt(Coordinates coordinates, out SpaceObject? spaceObject);
}
