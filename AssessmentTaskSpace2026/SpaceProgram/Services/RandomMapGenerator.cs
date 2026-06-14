namespace SpaceProgram.Services;

using Interfaces;
using Factories.Interfaces;
using Utilities.Interfaces;
using GCommon.Enums;

using SpaceProgram.Models;
using SpaceProgram.Models.Interfaces;
using SpaceProgram.Models.SpaceObjects;

using static GCommon.Constants.ApplicationConstants;

public class RandomMapGenerator : IMapGenerator
{
    private readonly IRandomGenerator _generator;
    private readonly ISpaceObjectFactory _factory;
    
    private readonly IDictionary<Coordinates, SpaceObject> _cells;
    private readonly IList<Coordinates> _availableCoordinates;

    private Coordinates _spaceStationCoordinates;
    private readonly ICollection<Coordinates> _astronautCoordinates;
    
    public RandomMapGenerator(IRandomGenerator randomGenerator, ISpaceObjectFactory spaceObjectFactory)
    {
        _generator = randomGenerator;
        _factory = spaceObjectFactory;
        
        _cells = new Dictionary<Coordinates, SpaceObject>();
        _availableCoordinates = new List<Coordinates>();

        _spaceStationCoordinates = new Coordinates();
        _astronautCoordinates = new List<Coordinates>();
    }
    
    public ICosmicMap GenerateMap(int rows, int columns)
    {
        ClearCollections();
        InitializeCoordinates(rows, columns);
        GenerateSpaceStation();
        GenerateAstronauts();
        FillWithRandomTerrainTypes();
        
        ICosmicMap map = new CosmicMap(rows, columns, _cells, _spaceStationCoordinates, _astronautCoordinates);
        
        return map;
    }

    private void ClearCollections()
    {
        _cells.Clear();
        _availableCoordinates.Clear();
        _astronautCoordinates.Clear();
    }

    private void InitializeCoordinates(int rows, int columns)
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                Coordinates newCoordinates = new Coordinates(row, col);
                _availableCoordinates.Add(newCoordinates);
            }
        }
    }
    
    private void GenerateSpaceStation()
    {
        int randomIndex = _generator.GenerateIndex(0, _availableCoordinates.Count);
        
        Coordinates stationCoordinates = _availableCoordinates[randomIndex];

        SpaceObject spaceObject = _factory.CreateSpaceObject(SpaceObjectType.SpaceStation);

        _spaceStationCoordinates = stationCoordinates;
        _cells.Add(stationCoordinates, spaceObject);
        _availableCoordinates.RemoveAt(randomIndex);
    }
    
    private void GenerateAstronauts()
    {
        int astronautCount = _generator.GenerateAstronautCount();
        for (int i = 1; i <= astronautCount; i++)
        {
            int randomIndex = _generator.GenerateIndex(0, _availableCoordinates.Count);
            Coordinates astronautCoordinates = _availableCoordinates[randomIndex];
            
            SpaceObject astronauts = _factory.CreateAstronaut($"{AstronautSymbol}{i}");
            
            _astronautCoordinates.Add(astronautCoordinates);
            _cells.Add(astronautCoordinates, astronauts);
            _availableCoordinates.RemoveAt(randomIndex);
        }
    }

    private void FillWithRandomTerrainTypes()
    {
        foreach (Coordinates coordinates in _availableCoordinates)
        {
            SpaceObjectType terrainType = GetRandomTerrainType();
            SpaceObject spaceObject = _factory.CreateSpaceObject(terrainType);
            _cells.Add(coordinates, spaceObject);
        }
        
        _availableCoordinates.Clear();
    }
    
    private SpaceObjectType GetRandomTerrainType()
    {
        SpaceObjectType[] terrainTypes =
        {
            SpaceObjectType.Asteroid,
            SpaceObjectType.OpenSpace,
            SpaceObjectType.SpaceDebris
        };

        int randomIndex = _generator.GenerateIndex(0, terrainTypes.Length);

        return terrainTypes[randomIndex];
    }
}
