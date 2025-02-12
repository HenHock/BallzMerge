using System.Linq;
using Project.Extensions;
using UnityEngine;

namespace Project.Balance
{
    [CreateAssetMenu(menuName = "Configs/Round/NumberConfig", fileName = "BlockNumberConfigs")]
    public class RoundNumberConfigs : ScriptableObject
    {
        [SerializeField] private RoundNumberData[] configs;

        public Vector2Int GetPossibleNumber(int currentRound)
        {
            RoundNumberData roundNumberData = configs.FirstOrDefault(config => config.RoundRange.InRange(currentRound));

            return IsDefault(roundNumberData)
                ? configs.Last().BlockNumberRange
                : roundNumberData.BlockNumberRange;
        }

        private bool IsDefault(RoundNumberData roundNumberData) => 
            roundNumberData.BlockNumberRange == default;
    }
}