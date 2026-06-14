namespace SpaceProgram.Services;

using Interfaces;
using Models;
using SpaceProgram.Models.Interfaces;
using SpaceProgram.Models;
using SpaceProgram.Models.SpaceObjects;
using Algorithms.Interfaces;

public class MissionService : IMissionService
{
    private readonly IPathFinder _pathFinder;
    
    public MissionService(IPathFinder pathFinder)
    {
        _pathFinder = pathFinder;
    }

    public MissionReport ProcessMissions(ICosmicMap map)
    {
        ICollection<MissionResult> results = new List<MissionResult>();
        
        MenageAstronauts(map, results);

        IEnumerable<MissionResult> failedMissions = results
            .Where(mr => !mr.IsSuccessful)
            .OrderBy(rm => rm.AstronautName);

        IEnumerable<MissionResult> successfulMissions = results
            .Where(mr => mr.IsSuccessful)
            .OrderBy(mr => mr.TotalMovementCost)
            .ThenBy(mr => mr.AstronautName);

        MissionReport report = new MissionReport(failedMissions, successfulMissions);
        
        return report;
    }

    private void MenageAstronauts(ICosmicMap map, ICollection<MissionResult> results)
    {
        ICollection<Coordinates> allAstronautsCoordinates = map.AstronautsCoordinates;
        Coordinates spaceStation = map.SpaceStationCoordinates;
        
        foreach (Coordinates astronautCoordinates in allAstronautsCoordinates)
        {
            MissionResult astronautMissionResult = _pathFinder.FindPath(map, astronautCoordinates, spaceStation);
            
            SpaceObject astronautObject = map.GetObjectAt(astronautCoordinates);
            string astronautName = astronautObject.DisplaySymbol;
            
            astronautMissionResult.AstronautName = astronautName;
            astronautMissionResult.StartCoordinates = astronautCoordinates;
            
            results.Add(astronautMissionResult);
        }
    }
}
