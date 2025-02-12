using System;

namespace Project.Logic.Grid.Data
{
    public readonly struct TileID : IEquatable<TileID>
    {
        public int Row { get; }
        public int Column { get; }

        public TileID(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public bool Equals(TileID other) => 
            Row == other.Row && Column == other.Column;

        public override bool Equals(object obj) => 
            obj is TileID other && Equals(other);

        public override int GetHashCode() => 
            HashCode.Combine(Row, Column);
    }
}