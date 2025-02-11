using System;
using NaughtyAttributes;
using UnityEngine;

namespace Project.Balance
{
    [Serializable]
    public struct RoundDropData
    {
        [MinMaxSlider(1, 50)]
        public Vector2Int RoundRange;
        
        public DropChanceData[] DropData;
    }
}