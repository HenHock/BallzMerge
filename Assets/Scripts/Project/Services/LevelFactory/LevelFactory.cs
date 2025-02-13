﻿using System.Linq;
using Project.Balance;
using Project.Extensions;
using Project.Logic.Block;
using Project.Logic.Block.Data;
using Project.Services.BlockProvider;
using Project.Services.Grid;
using Project.Services.Grid.Data;
using Project.Services.LevelFactory.Data;
using UnityEngine;
using Zenject;
using ILogger = Project.Infrastructure.Logger.ILogger;
using Random = UnityEngine.Random;

namespace Project.Services.LevelFactory
{
    public class LevelFactory : ILevelFactory, ILogger
    {
        public bool IsActiveLogger => true;
        public Color DefaultColor => Color.red;
        
        public Transform PlayerTransform { get; private set; }

        private readonly LevelConfig _levelConfig;
        private readonly ITileGridMap _tileGridMap;
        private readonly IBlocksProvider _blocksProvider;
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
            ITileGridMap tileGridMap,
            IBlocksProvider blocksProvider)
        {
            _instantiator = instantiator;
            _levelConfig = levelConfig;
            _roundDropConfigs = roundDropConfigs;
            _roundNumberConfigs = roundNumberConfigs;
            _blockColorConfig = blockColorConfig;
            _tileGridMap = tileGridMap;
            _blocksProvider = blocksProvider;
        }

        public void CreatePlayer() =>
            PlayerTransform = _instantiator.InstantiatePrefab(_levelConfig.PlayerPrefab, _levelConfig.PlayerSpawnPosition, Quaternion.identity, null).transform;

        public void CreateBlocks(int currentRound)
        {
            int blockCount = Random.Range(_roundDropConfigs.BlockPerRound.x, _roundDropConfigs.BlockPerRound.y);
            
            for (int i = 0; i < blockCount; i++)
            {
                int number = GetRandomNumber(currentRound);
                Tile emptyTile = _tileGridMap.GetRandomEmptyTile(_tileGridMap.Tiles.Length - 1);
                BlockBehavior block = _instantiator.InstantiatePrefabForComponent<BlockBehavior>(_levelConfig.BlockPrefab, emptyTile.Position, Quaternion.identity, null);
                
                emptyTile.SetBusy();
                block.Initialize(number, emptyTile.TileID, _blockColorConfig.GetColor(number));
                _blocksProvider.AddBlock(block);
                
                this.Log($"Created a block with number {number}");
            }
        }

        public void Cleanup() => Object.Destroy(PlayerTransform.gameObject);

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