using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks.Triggers;
using Project.Balance;
using Project.Extensions;
using Project.Logic.Block;
using Project.Logic.Block.Data;
using Project.Logic.Grid;
using Project.Logic.Grid.Data;
using Project.Logic.LevelFactory.Data;
using UnityEngine;
using Zenject;
using ILogger = Project.Infrastructure.Logger.ILogger;
using Random = UnityEngine.Random;

namespace Project.Logic.LevelFactory
{
    public class LevelFactory : ILevelFactory, ILogger
    {
        public bool IsActiveLogger => true;
        public Color DefaultColor => Color.red;
        
        public Transform PlayerTransform { get; private set; }
        public List<BlockMovement> Blocks { get; private set; }

        private readonly LevelConfig _levelConfig;
        private readonly ITileGridMap _tileGridMap;
        private readonly IInstantiator _instantiator;
        private readonly RoundDropConfigs _roundDropConfigs;
        private readonly RoundNumberConfigs _roundNumberConfigs;
        private readonly BlockColorConfig _blockColorConfig;

        public LevelFactory(
            IInstantiator instantiator,
            LevelConfig levelConfig,
            RoundDropConfigs roundDropConfigs, 
            RoundNumberConfigs roundNumberConfigs,
            BlockColorConfig blockColorConfig,
            ITileGridMap tileGridMap)
        {
            _instantiator = instantiator;
            _levelConfig = levelConfig;
            _roundDropConfigs = roundDropConfigs;
            _roundNumberConfigs = roundNumberConfigs;
            _blockColorConfig = blockColorConfig;
            _tileGridMap = tileGridMap;
            
            Blocks = new List<BlockMovement>();
        }

        public void CreatePlayer() =>
            PlayerTransform = _instantiator.InstantiatePrefab(_levelConfig.PlayerPrefab, _levelConfig.PlayerSpawnPosition, Quaternion.identity, null).transform;

        public void CreateBlocks()
        {
            int currentRound = 1;
            int blockCount = Random.Range(_roundDropConfigs.BlockPerRound.x, _roundDropConfigs.BlockPerRound.y);
            
            for (int i = 0; i < blockCount; i++)
            {
                int number = GetRandomNumber(currentRound);
                Tile emptyTile = _tileGridMap.GetRandomEmptyTile(_tileGridMap.Tiles.Length - 1);
                BlockView block = _instantiator.InstantiatePrefabForComponent<BlockView>(_levelConfig.BlockPrefab, emptyTile.Position, Quaternion.identity, null);
                
                emptyTile.SetBusy();
                block.Initialize(number, _blockColorConfig.GetColor(number));

                var blockMovement = block.GetComponent<BlockMovement>();
                blockMovement.Initialize(emptyTile.Row, emptyTile.Column);
                
                Blocks.Add(blockMovement);
                this.Log($"Created a block with number {number}");
            }
        }

        private int GetRandomNumber(int currentRound)
        {
            float chance = Random.Range(0f, 1f);
            Vector2Int possibleNumber = _roundNumberConfigs.GetPossibleNumber(currentRound);
            DropChanceData[] dropChances = _roundDropConfigs.GetNumberChances(currentRound)
                .Where(data => possibleNumber.InRange(data.Number))
                .OrderBy(data => data.Chance)
                .ToArray();

            float cumulative = 0f;
            foreach (var data in dropChances)
            {
                cumulative += data.Chance;
                if (chance <= cumulative)
                    return data.Number; 
            }
            
            // Default fallback (should not reach here if data is properly configured)
            return dropChances.LastOrDefault().Number;
        }
    }
}