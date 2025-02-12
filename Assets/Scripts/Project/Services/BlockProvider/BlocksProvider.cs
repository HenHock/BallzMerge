using System.Collections.Generic;
using System.Linq;
using Project.Logic.Block;
using Project.Services.Grid.Data;
using UnityEngine;

namespace Project.Services.BlockProvider
{
    public class BlocksProvider : IBlocksProvider
    {
        public IEnumerable<BlockBehavior> Blocks => _blocks;
        
        private readonly List<BlockBehavior> _blocks = new();

        public void AddBlock(BlockBehavior block) => _blocks.Add(block);
        
        public void RemoveBlock(BlockBehavior block) => _blocks.Remove(block);
        
        public BlockBehavior GetBlockOnTile(TileID tileID) => 
            _blocks.FirstOrDefault(block => block.TileID.Equals(tileID));

        public void Cleanup()
        {
            _blocks.ForEach(block => Object.Destroy(block.gameObject));
            _blocks.Clear();
        }
    }
}