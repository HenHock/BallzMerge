using DG.Tweening;
using Project.Logic.BlockProvider;
using Project.Logic.Grid;
using Project.Logic.Grid.Data;
using UnityEngine;
using Zenject;

namespace Project.Logic.Block
{
    public class BlockMovement : MonoBehaviour
    {
        private BlockBehavior _block;
        private ITileGridMap _tileGridMap;
        private IBlocksProvider _blocksProvider;

        [Inject]
        private void Construct(ITileGridMap tileGridMap, IBlocksProvider blocksProvider)
        {
            _blocksProvider = blocksProvider;
            _tileGridMap = tileGridMap;
        }

        public void Initialize(BlockBehavior block)
        {
            _block = block;
        }
        
        public void MoveTo(Tile tile)
        {
            _tileGridMap.GetTile(_block.TileID).SetEmpty();
            _block.TileID = tile.TileID;
            tile.SetBusy();
            
            transform.DOMove(tile.Position, 0.5f)
                .SetEase(Ease.OutCubic)
                .Play();
        }

        public void MoveTo(DirectionType direction)
        {
            Tile nextTile = _tileGridMap.GetNextTile(_block.TileID, direction);
            if (nextTile != null)
            {
                if (nextTile.IsEmpty)
                    MoveTo(nextTile);
                else
                {
                    BlockBehavior blockOnTile = _blocksProvider.GetBlockOnTile(nextTile.TileID);
                    if (blockOnTile.Number == _block.Number)
                    {
                        blockOnTile.MergeWith(_block);
                        _block.MergeWith(blockOnTile);
                    }
                }
            }
        }
    }
}