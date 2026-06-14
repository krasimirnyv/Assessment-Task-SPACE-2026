namespace SpaceProgram.Algorithms.Interfaces;

using Models;
using Models.Interfaces;
using Services.Models;

public interface IPathFinder
{
    MissionResult FindPath(ICosmicMap map, Coordinates start, Coordinates destination);
}