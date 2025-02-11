using Project.Logic.Grid.Data;
using UnityEngine;

namespace Project.Logic.Grid.Generator
{
    public interface ITileMapGenerator
    {
        public Tile[,] CreateMap(TileMapConfig tileMapConfig, Vector2 startPoint);
    }
}