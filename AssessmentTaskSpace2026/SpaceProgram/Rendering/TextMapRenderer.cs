namespace SpaceProgram.Rendering;

using Interfaces;
using Models;
using Models.Interfaces;
using Models.SpaceObjects;
using Services.Models;
using Utilities.Interfaces;

using static GCommon.Constants.ApplicationConstants;

public class TextMapRenderer : IMapRenderer
{
    private readonly IStringAppender _appender;
    
    public TextMapRenderer(IStringAppender appender)
    {
        _appender = appender;
    }
    
    public string Render(ICosmicMap map)
    {
        _appender.Clear();
        for (int row = 0; row < map.Rows; row++)
        {
            _appender.Append("\t");
            for (int col = 0; col < map.Columns; col++)
            {
                Coordinates coordinates = new Coordinates(row, col);
                AddMapCell(map, coordinates);
            }
            
            _appender.AppendLine();
        }
        
        return _appender.ToString();
    }

    public string Render(ICosmicMap map, MissionReport report)
    {
        _appender.Clear();
        
        IReadOnlyCollection<MissionResult> failedMissions = report.FailedMissions;
        ProcessFailedMissions(failedMissions);

        IReadOnlyCollection<MissionResult> successfulMissions = report.SuccessfulMissions;
        ProcessSucceededMissions(successfulMissions, map);
        
        return _appender.ToString();
    }
    
    private void AddMapCell(ICosmicMap map, Coordinates coordinates)
    {
        if (!map.TryGetObjectAt(coordinates, out SpaceObject? spaceObject))
        {
            _appender.Append(MissingSymbol.PadRight(CellWidth));
            return;
        }
                
        string symbol = spaceObject!.DisplaySymbol;
        _appender.Append(symbol.PadRight(CellWidth));
    }
    
    private void ProcessFailedMissions(IReadOnlyCollection<MissionResult> failedMissions)
    {
        foreach (MissionResult failed in failedMissions)
        {
            _appender.AppendLine();
            _appender.Append(string.Format(failed.Message, failed.AstronautName));
        }
    }
    
    private void ProcessSucceededMissions(IReadOnlyCollection<MissionResult> successfulMissions, ICosmicMap map)
    {
        foreach (MissionResult success in successfulMissions)
        {
            _appender.AppendLine();
            
            _appender.AppendLine(success is { TotalMovementCost: 1 }
                ? string.Format(success.Message, success.AstronautName, success.TotalMovementCost, string.Empty)
                : string.Format(success.Message, success.AstronautName, success.TotalMovementCost, PluralStepsSuffix));

            HashSet<Coordinates> path = success.Path.ToHashSet();
            Coordinates stationCoordinate = map.SpaceStationCoordinates;
            
            for (int row = 0; row < map.Rows; row++)
            {
                _appender.Append("\t");
                for (int col = 0; col < map.Columns; col++)
                {
                    Coordinates currentCoordinates = new Coordinates(row, col);

                    if (path.Contains(currentCoordinates) &&
                        !currentCoordinates.Equals(success.StartCoordinates) &&
                        !currentCoordinates.Equals(stationCoordinate))
                    {
                        AddMapPath(); 
                        continue;
                    }
                    
                    AddMapCell(map, currentCoordinates);
                }
            
                _appender.AppendLine();
            }
        }
    }

    private void AddMapPath()
    {
        string symbol = JourneySymbol;
        _appender.Append(symbol.PadRight(CellWidth));
    }
}
