using Project.Logic.LevelFactory.Data;
using UnityEngine;
using Zenject;

namespace Project.Logic.LevelFactory
{
    public class LevelFactory : ILevelFactory
    {
        public Transform PlayerTransform { get; private set; }

        private readonly LevelConfig _levelConfig;
        private readonly IInstantiator _instantiator;

        public LevelFactory(IInstantiator instantiator, LevelConfig levelConfig)
        {
            _instantiator = instantiator;
            _levelConfig = levelConfig;
        }

        public void CreatePlayer() => 
            PlayerTransform = _instantiator.InstantiatePrefab(_levelConfig.PlayerPrefab, _levelConfig.PlayerSpawnPosition, Quaternion.identity, null).transform;
    }
}