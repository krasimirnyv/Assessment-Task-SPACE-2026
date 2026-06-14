namespace SpaceProgram.Algorithms;

using Interfaces;
using Helpers.Interfaces;

using Models;
using Models.Interfaces;
using Services.Models;

public class BfsPathFinder : IPathFinder
{
    private readonly IPathResultBuilder _pathResultBuilder;
    
    public BfsPathFinder(IPathResultBuilder pathResultBuilder)
    {
        _pathResultBuilder = pathResultBuilder;
    }

    public MissionResult FindPath(ICosmicMap map, Coordinates start, Coordinates destination)
    {
        IDictionary<Coordinates, int> steps = new Dictionary<Coordinates, int>();
        IDictionary<Coordinates, Coordinates> previous = new Dictionary<Coordinates, Coordinates>();

        Queue<Coordinates> queue = new Queue<Coordinates>();
        HashSet<Coordinates> visited = [start];

        queue.Enqueue(start);
        steps[start] = 0;

        while (queue.Count > 0)
        {
            queue.TryDequeue(out Coordinates current);

            if (current == destination)
                break;

            IEnumerable<Coordinates> walkableNeighbours = map.GetWalkableNeighbours(current);
            foreach (Coordinates neighbourCoordinates in walkableNeighbours)
            {
                if (!visited.Add(neighbourCoordinates))
                    continue;

                int newSteps = steps[current] + 1;
                steps[neighbourCoordinates] = newSteps;
                previous[neighbourCoordinates] = current;
                queue.Enqueue(neighbourCoordinates);
            }
        }

        MissionResult result = BuildMissionResult(start, destination, steps, previous);

        return result;
    }


    private MissionResult BuildMissionResult(Coordinates start, Coordinates destination, 
                                                     IDictionary<Coordinates, int> steps, 
                                                     IDictionary<Coordinates, Coordinates> previous)
    {
        MissionResult result = !steps.TryGetValue(destination, out _) 
                             ? _pathResultBuilder.BuildFailedResult() 
                             : _pathResultBuilder.BuildSuccessfulResult(start, destination, steps[destination], previous);

        return result;
    }
}