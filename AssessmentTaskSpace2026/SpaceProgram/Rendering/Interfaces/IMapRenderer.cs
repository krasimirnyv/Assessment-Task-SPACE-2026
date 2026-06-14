namespace SpaceProgram.Rendering.Interfaces;

using Models.Interfaces;
using Services.Models;

public interface IMapRenderer
{
    string Render(ICosmicMap map);

    string Render(ICosmicMap map, MissionReport report);
}