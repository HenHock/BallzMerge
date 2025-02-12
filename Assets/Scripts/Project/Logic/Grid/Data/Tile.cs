using UnityEngine;

namespace Project.Logic.Grid.Data
{
    public class Tile
    {
        public int Row { get; private set; }
        public int Column { get; private set; }
        
        public Vector2 Position { get; private set; }
        public bool IsEmpty { get; private set;}

        public Tile(int row, int column, Vector2 position)
        {
            Row = row;
            Column = column;
            IsEmpty = true;
            Position = position;
        }

        public void SetEmpty() => IsEmpty = true;

        public void SetBusy() => IsEmpty = false;
    }
}