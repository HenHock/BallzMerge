using Project.Logic.Block.View;
using Project.Logic.Grid.Data;
using UnityEngine;

namespace Project.Logic.Block
{
    public class BlockBehavior : MonoBehaviour
    {
        public TileID TileID { get; set; }
        public int Number { get; private set; }
        public BlockView BlockView { get; private set; }
        public BlockMovement BlockMovement { get; private set; }

        private void Awake()
        {
            BlockView = GetComponent<BlockView>();
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
            
        }
    }
}