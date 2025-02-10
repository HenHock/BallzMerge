using NaughtyAttributes;
using UnityEngine;

namespace Project.Infrastructure
{
    [CreateAssetMenu(menuName = "Configs/GameConfig", fileName = "GameConfig")]
    public class GameConfig : ScriptableObject
    {
        [Scene] public int GameplayScene;
    }
}