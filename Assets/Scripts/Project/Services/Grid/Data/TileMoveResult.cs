namespace Project.Services.Grid.Data
{
    public enum TileMoveResult
    {
        /// <summary>The next tile is reachable, empty, and not at the end of the grid.</summary>
        Reachable = 0,
        /// <summary>The next tile is out of bounds or not empty; it cannot be reached.</summary>
        Unreachable = 1,
        /// <summary>The next tile is empty and at the end of the grid; the game is considered over.</summary>
        GameOver = 2,
    }
}