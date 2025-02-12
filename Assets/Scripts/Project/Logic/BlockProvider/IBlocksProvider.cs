using System.Collections.Generic;
using Project.Logic.Block;
using Project.Logic.Grid.Data;

namespace Project.Logic.BlockProvider
{
    public interface IBlocksProvider
    {
        BlockBehavior GetBlockOnTile(TileID tileID);
        void AddBlock(BlockBehavior block);
        IEnumerable<BlockBehavior> Blocks { get; }
        void RemoveBlock(BlockBehavior block);
    }
}