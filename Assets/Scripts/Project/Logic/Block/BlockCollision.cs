using System;
using UnityEngine;
using Project.Extensions;
using Project.Services.Grid.Data;

namespace Project.Logic.Block
{
    public class BlockCollision : MonoBehaviour
    {
        private BlockBehavior _block;

        private void Start() => 
            _block = GetComponent<BlockBehavior>();

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.transform.IsPlayer())
            {
                Vector3 direction = (transform.position - other.transform.position).normalized;
                DirectionType directionType = GetDirectionType(direction);

                _block.BlockMovement.MoveTo(directionType);
            }
        }

        private DirectionType GetDirectionType(Vector2 direction)
        {
            if (Math.Abs(direction.y) > Math.Abs(direction.x))
            {
                if (direction.y > 0)
                    return DirectionType.Up;
                
                return DirectionType.Down;
            }

            if (direction.x > 0)
                return DirectionType.Right;
                
            return DirectionType.Left;
        }
    }
}