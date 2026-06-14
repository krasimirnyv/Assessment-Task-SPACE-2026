namespace SpaceProgram.Services.Interfaces;

using SpaceProgram.Models.Interfaces;

public interface IMapGenerator
{
    ICosmicMap GenerateMap(int rows, int columns);
}