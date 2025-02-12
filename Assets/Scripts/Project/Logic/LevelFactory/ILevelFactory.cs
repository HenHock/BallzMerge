using System.Collections.Generic;
using Project.Logic.Block;
using UnityEngine;

namespace Project.Logic.LevelFactory
{
    public interface ILevelFactory
    {
        Transform PlayerTransform { get; }
        void CreatePlayer();
        void CreateBlocks();
    }
}