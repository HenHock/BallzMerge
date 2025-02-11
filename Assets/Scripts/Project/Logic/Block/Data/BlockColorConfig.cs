using System;
using NaughtyAttributes;
using UnityEngine;

namespace Project.Logic.Block.Data
{
    [CreateAssetMenu(menuName = "Configs/BlockColorConfig", fileName = "BlockColorConfig")]
    public class BlockColorConfig : ScriptableObject
    {
        [InfoBox("The array of colors for block where index of array represents number of block. " +
                 "By default get color by 0 index")]
        [SerializeField] private Color[] colors = Array.Empty<Color>();

        public Color GetColor(int number)
        {
            if (number >= 1 && number < colors.Length) 
                return colors[number];

            return colors[0];
        }
    }
}