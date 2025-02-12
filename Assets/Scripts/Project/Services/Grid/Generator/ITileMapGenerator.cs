using Project.Services.Grid.Data;
using UnityEngine;

namespace Project.Services.Grid.Generator
{
    public interface ITileMapGenerator
    {
        public Tile[,] CreateMap(TileMapConfig tileMapConfig, Vector2 startPoint);
    }
}