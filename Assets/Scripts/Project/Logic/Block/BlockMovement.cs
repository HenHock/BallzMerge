using DG.Tweening;
using Project.Logic.Grid.Data;
using UnityEngine;

namespace Project.Logic.Block
{
    public class BlockMovement : MonoBehaviour
    {
        public TileID TileID { get; private set;}

        public void Initialize(int row, int column) =>
            TileID = new TileID(row, column);

        public void Move(Tile tile)
        {
            TileID = new TileID(tile.Row, tile.Column);
            transform.DOMove(tile.Position, 0.5f)
                .SetEase(Ease.OutCubic)
                .Play();
        }
    }
}