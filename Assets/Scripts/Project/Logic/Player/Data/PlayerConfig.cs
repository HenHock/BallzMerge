using UnityEngine;

namespace Project.Logic.Player.Data
{
    [CreateAssetMenu(menuName = "Configs/PlayerConfig", fileName = "PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        public float Speed = 50;
    }
}