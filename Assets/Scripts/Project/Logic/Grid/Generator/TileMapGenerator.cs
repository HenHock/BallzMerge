using Project.Logic.Grid.Data;
using UnityEngine;

namespace Project.Logic.Grid.Generator
{
    public class TileMapGenerator
    {
        public static Tile[][] CreateMap(TileMapConfig tileMapConfig, Vector2 startPoint)
        {
            var tiles = new Tile[tileMapConfig.MapSize.y + 1][];
            
            for (var row = 0; row < tileMapConfig.MapSize.y + 1; row++)
            {
                tiles[row] = new Tile[tileMapConfig.MapSize.x];
                for (var column = 0; column < tileMapConfig.MapSize.x; column++)
                    tiles[row][column] = new Tile(row, column, CalculatePosition(row, column, tileMapConfig, startPoint));
            }

            return tiles;
        }

        private static Vector2 CalculatePosition(int row, int column, TileMapConfig tileMapConfig, Vector2 startPoint)
        {
            float weight = tileMapConfig.TileSize.x;
            float height = tileMapConfig.TileSize.y;
            
            return startPoint + tileMapConfig.MapOffSet + Vector2.up * (row * height) + Vector2.right * (column * weight);
        }

    }
}