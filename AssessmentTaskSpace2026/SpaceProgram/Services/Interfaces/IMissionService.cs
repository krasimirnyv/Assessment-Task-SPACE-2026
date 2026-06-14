namespace SpaceProgram.Services.Interfaces;

using Models;
using SpaceProgram.Models.Interfaces;

public interface IMissionService
{
    MissionReport ProcessMissions(ICosmicMap map);
}