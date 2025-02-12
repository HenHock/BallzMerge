using UnityEngine;

namespace Project.Services.Grid.Data
{
    public class Tile
    {
        public TileID TileID { get; }

        public bool IsEmpty { get; private set;}
        public Vector2 Position { get; private set; }

        public Tile(int row, int column, Vector2 position)
        {
            IsEmpty = true;
            Position = position;
            TileID = new TileID(row, column);
        }

        public void SetEmpty() => IsEmpty = true;

        public void SetBusy() => IsEmpty = false;
    }
}