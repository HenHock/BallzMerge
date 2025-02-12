using UnityEngine;

namespace Project.Services.Grid.Data
{
    [CreateAssetMenu(menuName = "Configs/TileMapConfig", fileName = "TileMapConfig")]
    public class TileMapConfig : ScriptableObject
    {
        public Vector2Int MapSize = new(5, 7);
        public Vector2 MapOffSet = new Vector2(0, 0);
        public Vector2 TileSize = new(100, 100);
    }
}