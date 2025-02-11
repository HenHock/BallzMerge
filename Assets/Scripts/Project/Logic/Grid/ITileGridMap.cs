using Project.Logic.Grid.Data;
using UnityEngine;

namespace Project.Logic.Grid
{
    public interface ITileGridMap
    {
        void Initialize();
        Tile[][] Tiles { get; }
        Tile GetRandomEmptyTile(int row);
    }
}