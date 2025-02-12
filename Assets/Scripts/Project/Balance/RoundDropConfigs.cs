using System.Linq;
using NaughtyAttributes;
using Project.Extensions;
using UnityEngine;

namespace Project.Balance
{
    [CreateAssetMenu(menuName = "Configs/Round/DropConfig", fileName = "BlockDropConfigs")]
    public class RoundDropConfigs : ScriptableObject
    {
        [MinMaxSlider(1, 5)]
        public Vector2Int BlockPerRound = new(1, 4);

        [SerializeField] private RoundDropData[] configs;

        public DropChanceData[] GetNumberChances(int currentRound)
        {
            RoundDropData roundDropData = configs.FirstOrDefault(config => config.RoundRange.InRange(currentRound));
            return IsDefault(roundDropData) ? configs.Last().DropData : roundDropData.DropData;
        }

        private bool IsDefault(RoundDropData roundDropData) => 
            roundDropData.RoundRange == default;
    }
}