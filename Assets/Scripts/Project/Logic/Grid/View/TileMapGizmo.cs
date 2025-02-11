using NaughtyAttributes;
using Project.Logic.Grid.Data;
using Project.Logic.Grid.Generator;
using Project.Logic.LevelFactory.Data;
using UnityEngine;
using Zenject;

namespace Project.Logic.Grid.View
{
    public class TileMapGizmo : MonoBehaviour
    {
        [Expandable]
        [SerializeField] private TileMapConfig tileMapConfig;
        
        [Expandable]
        [SerializeField] private LevelConfig levelConfig;

        private Tile[][] _tiles;
        private ITileGridMap _tileGridMap;

        [Inject]
        private void Construct(ITileGridMap tileGridMap) => 
            _tileGridMap = tileGridMap;

        private void Start() => _tiles = _tileGridMap.Tiles;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            
            if (tileMapConfig != null && levelConfig != null)
            {
                _tiles ??= TileMapGenerator.CreateMap(tileMapConfig, levelConfig.GridStartPoint);

                foreach (Tile[] tiles in _tiles)
                foreach (Tile tile in tiles)
                {
                    Gizmos.DrawCube(tile.Position, Vector2.one * 0.25f);
                    Gizmos.DrawWireCube(tile.Position, tileMapConfig.TileSize);
                }
            }
        }

        [Button]
        private void Recalculate() => 
            _tiles = TileMapGenerator.CreateMap(tileMapConfig, levelConfig.GridStartPoint);
    }
}