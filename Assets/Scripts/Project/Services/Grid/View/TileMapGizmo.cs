using NaughtyAttributes;
using Project.Services.Grid.Data;
using Project.Services.Grid.Generator;
using Project.Services.LevelFactory.Data;
using UnityEngine;
using Zenject;

namespace Project.Services.Grid.View
{
    public class TileMapGizmo : MonoBehaviour
    {
#if UNITY_EDITOR
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
            if (tileMapConfig != null && levelConfig != null)
            {
                _tiles ??= TileMapGenerator.CreateMap(tileMapConfig, levelConfig.GridStartPoint);

                foreach (Tile tile in _tiles[0])
                {
                    Gizmos.color = Color.red;
                    Gizmos.DrawCube(tile.Position, Vector2.one * 0.25f);
                    Gizmos.DrawWireCube(tile.Position, tileMapConfig.TileSize);
                }
                
                for (var index = 1; index < _tiles.Length; index++)
                    foreach (var tile in _tiles[index])
                    {
                        Gizmos.color = Color.yellow;
                        Gizmos.DrawCube(tile.Position, Vector2.one * 0.25f);
                        Gizmos.DrawWireCube(tile.Position, tileMapConfig.TileSize);
                    }
            }
        }

        [Button]
        private void Recalculate() => 
            _tiles = TileMapGenerator.CreateMap(tileMapConfig, levelConfig.GridStartPoint);
#endif
    }
}
