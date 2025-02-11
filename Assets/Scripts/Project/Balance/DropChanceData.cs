using System;
using UnityEngine;

namespace Project.Balance
{
    [Serializable]
    public struct DropChanceData
    {
        [Min(1)] public int Number;
        [Range(0, 1)] public float Chance;
    }
}