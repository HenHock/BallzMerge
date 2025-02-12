using DG.Tweening;
using Project.Extensions;
using Project.Logic.Block.View;
using Project.Services.BlockProvider;
using Project.Services.Grid;
using Project.Services.Grid.Data;
using UnityEngine;
using Zenject;

namespace Project.Logic.Block
{
    public class BlockBehavior : MonoBehaviour
    {
        public TileID TileID { get; set; }
        public int Number { get; private set; }
        public BlockView BlockView { get; private set; }
        public BlockMovement BlockMovement { get; private set; }
        public bool IsDead { get; private set; }

        private Rigidbody2D _rigidbody2D;
        private IBlocksProvider _blocksProvider;
        private ITileGridMap _tileGridMap;

        [Inject]
        private void Construct(IBlocksProvider blocksProvider, ITileGridMap tileGridMap)
        {
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

        public void MergeWith(BlockBehavior block)
        {
            IsDead = true;
            _rigidbody2D.simulated = false;
            Vector2 direction = block.transform.position - transform.position;
            Vector2 endPoint = transform.position.ToVector2() + direction.normalized / 2 * direction.magnitude;

            _blocksProvider.RemoveBlock(this);
            _tileGridMap.GetTile(TileID).SetEmpty();
            
            BlockMovement.MoveTo(endPoint);
            BlockView.PlayDistroyTween();
        }
    }
}