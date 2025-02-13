using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Project.Extensions;
using Project.Logic.Block.View;
using Project.Services.AudioPlayer;
using Project.Services.BlockProvider;
using Project.Services.Grid;
using Project.Services.Grid.Data;
using UnityEngine;
using Zenject;

namespace Project.Logic.Block
{
    public class BlockBehavior : MonoBehaviour
    {
        public int Number { get; private set; }
        public TileID TileID { get; set; }
        public BlockView BlockView { get; private set; }
        public BlockMovement BlockMovement { get; private set; }
        public bool IsDead { get; private set; }

        private Rigidbody2D _rigidbody2D;
        private IBlocksProvider _blocksProvider;
        private ITileGridMap _tileGridMap;
        private IAudioPlayer _audioPlayer;

        [Inject]
        private void Construct(IBlocksProvider blocksProvider, ITileGridMap tileGridMap, IAudioPlayer audioPlayer)
        {
            _audioPlayer = audioPlayer;
            _tileGridMap = tileGridMap;
            _blocksProvider = blocksProvider;
        }

        private void Awake()
        {
            BlockView = GetComponent<BlockView>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
            BlockMovement = GetComponent<BlockMovement>();
        }

        public void Initialize(int number, TileID tileID, Color color)
        {
            Number = number;
            TileID = tileID;
            BlockView.Initialize(number, color);
            BlockMovement.Initialize(this);
        }

        public void ResolveMerge()
        {
            if (IsDead)
                return;
            
            Tile[] tilesAround = _tileGridMap.GetTilesAround(TileID);

            foreach (var tile in tilesAround)
            {
                if (tile?.IsEmpty == false)
                {
                    BlockBehavior blockOnTile = _blocksProvider.GetBlockOnTile(tile.TileID);
                    if (blockOnTile?.Number == Number && !blockOnTile.IsDead)
                    {
                        MergeWith(blockOnTile);
                        blockOnTile.MergeWith(this);
                        _audioPlayer.PlayDestroyBlock();
                        break;
                    }
                }
            }
        }

        private void MergeWith(BlockBehavior block)
        {
            IsDead = true;
            _rigidbody2D.simulated = false;

            BlockView.PlayDestroyTween();
            BlockMovement.MoveTo(GetMiddlePoint(block));
        }

        private Vector2 GetMiddlePoint(BlockBehavior block)
        {
            Vector2 direction = block.transform.position - transform.position;
            return transform.position.ToVector2() + direction.normalized * (direction.magnitude / 2);
        }

        private void OnDestroy()
        {
            DOTween.Kill(transform);
            _blocksProvider.RemoveBlock(this);
            _tileGridMap.GetTile(TileID).SetEmpty();
        }
    }
}