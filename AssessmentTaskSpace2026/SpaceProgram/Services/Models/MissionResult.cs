namespace SpaceProgram.Services.Models;

using SpaceProgram.Models;

public class MissionResult
{
    public string AstronautName { get; set; } = null!;

    public Coordinates StartCoordinates { get; set; }
    
    public bool IsSuccessful { get; init; }

    public double TotalMovementCost { get; init; }

    public string Message { get; init; } = null!;
    
    public IReadOnlyCollection<Coordinates> Path { get; init; } = [];
}