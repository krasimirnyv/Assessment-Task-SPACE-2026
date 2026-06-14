namespace SpaceProgram.Algorithms.Helpers;

using Interfaces;
using Models;
using Services.Models;

using static GCommon.Constants.Messages;

public class PathResultBuilder : IPathResultBuilder
{
    public MissionResult BuildFailedResult()
    {
        MissionResult result = new MissionResult
        {
            IsSuccessful = false,
            TotalMovementCost = double.PositiveInfinity,
            Message = MissionFailedMessage
        };

        return result;
    }

    public MissionResult BuildSuccessfulResult(Coordinates start, Coordinates destination, double totalCost, 
                                               IDictionary<Coordinates, Coordinates> previous)
    {
        IReadOnlyCollection<Coordinates> path = ReconstructPath(start, destination, previous);

        MissionResult result = new MissionResult
        {
            IsSuccessful = true,
            TotalMovementCost = totalCost,
            Message = MissionSucceededMessage,
            Path = path
        };
        
        return result;
    }

    private IReadOnlyCollection<Coordinates> ReconstructPath(Coordinates start, Coordinates destination, IDictionary<Coordinates, Coordinates> previous)
    {
        Stack<Coordinates> path = new Stack<Coordinates>();

        Coordinates current = destination;

        while (!current.Equals(start))
        {
            path.Push(current);
            current = previous[current];
        }
            
        path.Push(start);
        return path.ToList().AsReadOnly();
    }
}