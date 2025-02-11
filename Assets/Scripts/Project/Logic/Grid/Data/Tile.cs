using UnityEngine;

namespace Project.Logic.Grid.Data
{
    public class Tile
    {
        public Vector2 Position { get; private set; }
        
        public bool IsEmpty { get; private set;}

        public Tile(Vector2 position)
        {
            IsEmpty = true;
            Position = position;
        }

        public void SetEmpty() => IsEmpty = true;

        public void SetBusy() => IsEmpty = false;
    }
}