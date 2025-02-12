using System.Collections.Generic;
using System.Linq;
using Project.Logic.Block;
using Project.Logic.Grid.Data;

namespace Project.Logic.BlockProvider
{
    public class BlocksProvider : IBlocksProvider
    {
        public IEnumerable<BlockBehavior> Blocks => _blocks;
        
        private readonly List<BlockBehavior> _blocks = new();

        public void AddBlock(BlockBehavior block) => _blocks.Add(block);
        
        public void RemoveBlock(BlockBehavior block) => _blocks.Remove(block);
        public BlockBehavior GetBlockOnTile(TileID tileID) => 
            _blocks.FirstOrDefault(block => block.TileID.Equals(tileID));
    }
}