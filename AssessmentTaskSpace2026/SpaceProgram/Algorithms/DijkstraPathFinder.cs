namespace SpaceProgram.Algorithms;

using Interfaces;
using Helpers.Interfaces;

using Models;
using Models.Interfaces;
using Models.SpaceObjects;
using Services.Models;

public class DijkstraPathFinder : IPathFinder
{
    private readonly IPathResultBuilder _pathResultBuilder;
    
    public DijkstraPathFinder(IPathResultBuilder pathResultBuilder)
    {
        _pathResultBuilder = pathResultBuilder;
    }
    
    public MissionResult FindPath(ICosmicMap map, Coordinates start, Coordinates destination)
    {
        IDictionary<Coordinates, double> distances = new Dictionary<Coordinates, double>();
        IDictionary<Coordinates, Coordinates> previous = new Dictionary<Coordinates, Coordinates>();
        
        InitializeDistance(map, distances);
        
        PriorityQueue<Coordinates, double> priorityQueue = new PriorityQueue<Coordinates, double>();
        
        distances[start] = 0;
        priorityQueue.Enqueue(start, distances[start]);
        
        HashSet<Coordinates> visited = new HashSet<Coordinates>();
        
        while (priorityQueue.Count > 0)
        {
            priorityQueue.TryDequeue(out Coordinates currentCoordinates, out double currentDistance);

            if (visited.Contains(currentCoordinates))
                continue;
            
            if (currentDistance > distances[currentCoordinates])
                continue;

            visited.Add(currentCoordinates);
            if (currentCoordinates == destination)
                break;

            IEnumerable<Coordinates> walkableNeighbours = map.GetWalkableNeighbours(currentCoordinates);
            foreach (Coordinates neighbourCoordinates in walkableNeighbours)
            {
                if (visited.Contains(neighbourCoordinates))
                    continue;
                
                SpaceObject neighbour = map.GetObjectAt(neighbourCoordinates);
                
                double newDistance = distances[currentCoordinates] + neighbour.MovementCost;
                if (newDistance < distances[neighbourCoordinates])
                {
                    distances[neighbourCoordinates] = newDistance;
                    previous[neighbourCoordinates] = currentCoordinates;
                    priorityQueue.Enqueue(neighbourCoordinates, newDistance);
                }
            }
        }

        MissionResult result = BuildMissionResult(start, destination, distances, previous);
        
        return result;
    }

    private static void InitializeDistance(ICosmicMap map, IDictionary<Coordinates, double> distances)
    {
        foreach (Coordinates coordinates in map.GetAllCoordinates())
            distances[coordinates] = double.PositiveInfinity;
    }
    
    private MissionResult BuildMissionResult(Coordinates start, Coordinates destination, 
                                                     IDictionary<Coordinates, double> distances, 
                                                     IDictionary<Coordinates, Coordinates> previous)
    {
        MissionResult result;

        if (!distances.TryGetValue(destination, out double value) || double.IsPositiveInfinity(value))
            result = _pathResultBuilder.BuildFailedResult();
        else
            result = _pathResultBuilder.BuildSuccessfulResult(start, destination, value, previous);

        return result;
    }
}
