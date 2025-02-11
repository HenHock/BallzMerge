using System.Linq;
using Project.Extensions;
using UnityEngine;

namespace Project.Balance
{
    [CreateAssetMenu(menuName = "Configs/Round/NumberConfig", fileName = "BlockNumberConfigs")]
    public class RoundNumberConfigs : ScriptableObject
    {
        [SerializeField] private RoundNumberData[] configs;

        public Vector2Int GetPossibleNumber(int currentRound) => 
            configs.FirstOrDefault(config => config.RoundRange.InRange(currentRound))
                .BlockNumberRange;
    }
}