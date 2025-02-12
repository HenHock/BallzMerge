using DG.Tweening;
using Project.Services.BlockProvider;
using Project.Services.Grid;
using Project.Services.Grid.Data;
using UnityEngine;
using Zenject;

namespace Project.Logic.Block
{
    public class BlockMovement : MonoBehaviour
    {
        private BlockBehavior _block;
        private ITileGridMap _tileGridMap;

        [Inject]
        private void Construct(ITileGridMap tileGridMap, IBlocksProvider blocksProvider)
        {
            _tileGridMap = tileGridMap;
        }

        public void Initialize(BlockBehavior block)
        {
            _block = block;
        }

        public void MoveTo(DirectionType direction)
        {
            Tile nextTile = _tileGridMap.GetNextTile(_block.TileID, direction);
            if (nextTile?.IsEmpty == true)
                MoveTo(nextTile);
        }

        public void MoveTo(Tile tile)
        {
            _tileGridMap.GetTile(_block.TileID).SetEmpty();
            _block.TileID = tile.TileID;
            tile.SetBusy();

            MoveTo(tile.Position);
        }

        public void MoveTo(Vector2 endPoint) =>
            transform.DOMove(endPoint, 0.5f)
                .SetEase(Ease.OutCubic)
                .OnComplete(() => _block.ResolveMerge())
                .Play();
    }
}