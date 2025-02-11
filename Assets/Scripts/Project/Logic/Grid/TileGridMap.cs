using System.Linq;
using Project.Logic.Grid.Data;
using Project.Logic.Grid.Generator;
using Project.Logic.LevelFactory.Data;
using UnityEngine;

namespace Project.Logic.Grid
{
    public class TileGridMap : ITileGridMap
    {
        public Tile[][] Tiles { get; private set; }

        private readonly LevelConfig _levelConfig;
        private readonly TileMapConfig _tileMapConfig;

        public TileGridMap(TileMapConfig tileMapConfig, LevelConfig levelConfig)
        {
            _levelConfig = levelConfig;
            _tileMapConfig = tileMapConfig;
        }

        public void Initialize()
        {
            Tiles = TileMapGenerator.CreateMap(_tileMapConfig, _levelConfig.GridStartPoint);
        }

        public Tile GetRandomEmptyTile(int row)
        {
            Tile[] sortedArray = Tiles[row]
                .Where(tile => tile.IsEmpty)
                .ToArray();

            return sortedArray[Random.Range(0, sortedArray.Length)];
        }
    }
}