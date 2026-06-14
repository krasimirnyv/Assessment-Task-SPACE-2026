namespace SpaceProgram.Algorithms.Helpers.Interfaces;

using Models;
using Services.Models;

public interface IPathResultBuilder
{
    MissionResult BuildFailedResult();
    
    MissionResult BuildSuccessfulResult(Coordinates start, Coordinates destination, double totalCost, IDictionary<Coordinates, Coordinates> previous);
}