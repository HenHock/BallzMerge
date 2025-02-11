using UnityEngine;

namespace Project.Logic.Aim.Data
{
    [CreateAssetMenu(menuName = "Configs/AimConfig", fileName = "AimConfig")]
    public class AimConfig : ScriptableObject
    {
        public float MaxDistance = 10;
        public LayerMask HitLayerMask;
    }
}