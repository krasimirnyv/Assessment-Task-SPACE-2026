namespace SpaceProgram.Models;

using Interfaces;
using SpaceObjects;

public class CosmicMap : ICosmicMap
{
    public CosmicMap(int rows, int columns,
                     IDictionary<Coordinates, SpaceObject> cells, 
                     Coordinates spaceStationCoordinates,
                     ICollection<Coordinates> astronautsCoordinates)
    {
        Rows = rows;
        Columns = columns;
        Cells = cells;
        SpaceStationCoordinates =  spaceStationCoordinates;
        AstronautsCoordinates = astronautsCoordinates;
    }

    public int Rows { get; }
    
    public int Columns { get; }
    
    public Coordinates SpaceStationCoordinates { get; }

    public ICollection<Coordinates> AstronautsCoordinates { get; }
    
    public IEnumerable<Coordinates> GetWalkableNeighbours(Coordinates coordinates)
    {
        IEnumerable<Coordinates> possibleNeighbours = new List<Coordinates>
        {
            new() { Row = coordinates.Row - 1, Column = coordinates.Column },
            new() { Row = coordinates.Row + 1, Column = coordinates.Column },
            new() { Row = coordinates.Row, Column = coordinates.Column - 1 },
            new() { Row = coordinates.Row, Column = coordinates.Column + 1 }
        };

        IEnumerable<Coordinates> walkableNeighbours = possibleNeighbours
            .Where(neighbour => IsInsideMap(neighbour) && GetObjectAt(neighbour).IsWalkable);
        
        return walkableNeighbours;
    }
    
    public ICollection<Coordinates> GetAllCoordinates()
        => Cells.Keys;
    
    public SpaceObject GetObjectAt(Coordinates coordinates)
        => Cells[coordinates];

    public bool TryGetObjectAt(Coordinates coordinates, out SpaceObject? spaceObject)
        => Cells.TryGetValue(coordinates, out spaceObject);
    
    private bool IsInsideMap(Coordinates coordinates) 
        => Cells.ContainsKey(coordinates);
    
    private IDictionary<Coordinates, SpaceObject> Cells { get; }
}
