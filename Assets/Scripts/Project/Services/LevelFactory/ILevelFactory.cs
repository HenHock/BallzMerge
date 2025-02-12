using UnityEngine;

namespace Project.Services.LevelFactory
{
    public interface ILevelFactory
    {
        Transform PlayerTransform { get; }
        void CreatePlayer();
        void CreateBlocks(int currentRound);
        void Cleanup();
    }
}