using System.Linq;
using System.Collections.Generic;
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
        private Dictionary<DirectionType, (int row, int col)> _directions;

        public TileGridMap(TileMapConfig tileMapConfig, LevelConfig levelConfig)
        {
            _levelConfig = levelConfig;
            _tileMapConfig = tileMapConfig;
        }

        public void Initialize()
        {
            Tiles = TileMapGenerator.CreateMap(_tileMapConfig, _levelConfig.GridStartPoint);
            
            _directions = new Dictionary<DirectionType, (int, int)>
            {
                [DirectionType.Left] = (-1, 0),
                [DirectionType.Right] = (1, 0),
                [DirectionType.Up] = (0, 1),
                [DirectionType.Down] = (0, -1),
            };
        }

        public Tile GetRandomEmptyTile(int row)
        {
            Tile[] sortedArray = Tiles[row]
                .Where(tile => tile.IsEmpty)
                .ToArray();

            return sortedArray[Random.Range(0, sortedArray.Length - 1)];
        }

        public Tile GetTile(TileID id) => Tiles[id.Row][id.Column];

        public Tile GetNextTile(Tile tile, DirectionType directionType)
        {
            (int Column, int Row) direction = _directions[directionType];

            int nextRow = tile.Row + direction.Row;
            if (nextRow < 0 || nextRow >= Tiles.Length)
                return null;

            int nextColumn = tile.Column + direction.Column;
            if (nextColumn < 0 || nextColumn >= Tiles[tile.Row].Length)
                return null;

            if (!Tiles[nextRow][nextColumn].IsEmpty)
                return null;
            
            return Tiles[nextRow][nextColumn];
        }

        public bool IsCrossedLastRow() => Tiles[0].Any(tile => !tile.IsEmpty);
    }
}