namespace Project.Logic.Grid.Data
{
    public struct TileID
    {
        public int Row { get; }
        public int Column { get; }

        public TileID(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}