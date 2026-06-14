namespace SpaceProgram.Models;

public readonly record struct Coordinates
{
    public Coordinates()
    {
    }
    
    public Coordinates(int row, int column)
    {
        Row = row;
        Column = column;
    }
    
    public int Row { get; init; }

    public int Column { get; init; }
}