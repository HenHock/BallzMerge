using System.Linq;
using NaughtyAttributes;
using Project.Logic.LevelFactory.SpawnPoint;
using UnityEngine;

namespace Project.Logic.LevelFactory.Data
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "Configs/LevelConfig")]
    public class LevelConfig : ScriptableObject
    {
        [BoxGroup("Ball")]
        public GameObject PlayerPrefab;
        [BoxGroup("Ball")]
        public Vector2 PlayerSpawnPosition;

        [BoxGroup("Grid")]
        public Vector2 GridStartPoint;
        [BoxGroup("Block")]
        public GameObject BlockPrefab;

        [Button]
        private void Fill()
        {
            PlayerSpawnPosition = FindObjectsByType<SpawnPoint.SpawnPoint>(FindObjectsInactive.Exclude, FindObjectsSortMode.None)?
                .FirstOrDefault(point => point.PointType == SpawnPointType.Player)?
                .transform.position ?? Vector3.zero;
        }
    }
}