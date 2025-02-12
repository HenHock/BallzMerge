using System.Collections.Generic;
using Project.Logic.Block;
using Project.Services.Grid.Data;

namespace Project.Services.BlockProvider
{
    public interface IBlocksProvider
    {
        BlockBehavior GetBlockOnTile(TileID tileID);
        void AddBlock(BlockBehavior block);
        IEnumerable<BlockBehavior> Blocks { get; }
        void RemoveBlock(BlockBehavior block);
        void Cleanup();
    }
}