using System;
using NaughtyAttributes;
using UnityEngine;

namespace Project.Balance
{
    [Serializable]
    public struct RoundNumberData
    {
        [MinMaxSlider(1, 50)]
        public Vector2Int RoundRange;

        [MinMaxSlider(1, 100)]
        public Vector2Int BlockNumberRange;
    }
}