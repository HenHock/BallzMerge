using UnityEditor;
using UnityEngine;

namespace Project.Logic.LevelFactory.SpawnPoint
{
    public class SpawnPoint : MonoBehaviour
    {
        [SerializeField] private SpawnPointType pointType;

        public SpawnPointType PointType => pointType;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, 0.5f);
            Handles.Label(transform.position + Vector3.up - Vector3.right * 2, $"{pointType} spawn point");
        }
    }
}