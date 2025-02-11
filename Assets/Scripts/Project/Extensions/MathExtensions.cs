using UnityEngine;

namespace Project.Extensions
{
    public static class MathExtensions
    {
        public static Vector2 CalculateReflectDirection(Vector2 first, Vector2 second)
        {
            Vector2 direction = first - second;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
            Vector2 axis = Mathf.Abs(angle) > 90 && angle < 270 ? Vector2.up : Vector2.right;

            return Vector2.Reflect(direction, axis).normalized;
        }
    }
}