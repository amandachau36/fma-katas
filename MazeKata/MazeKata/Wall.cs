namespace MazeKata
{
    public class Wall : ISpot
    {
        public bool IsWalkable { get; } = false;
    }
}