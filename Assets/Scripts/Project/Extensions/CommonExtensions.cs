using System;
using System.Linq;
using Project.StaticData;
using UnityEngine;
using ILogger = Project.Infrastructure.Logger.ILogger;

namespace Project.Extensions
{
    public static class CommonExtensions
    {
        public static void Log(this ILogger logger, string message, Color color = default)
        {
            if (!logger.IsActiveLogger)
                return;

            color = color == default ? logger.DefaultColor : color;
            Debug.Log($"<color=#{ColorUtility.ToHtmlStringRGBA(color)}>{logger.GetName()}:</color> {message}");
        }
        
        public static T With<T>(this T source, Action<T> action)
        {
            action.Invoke(source);
            return source;
        }

        public static string ToJson<TClass>(this TClass source) where TClass : class => JsonUtility.ToJson(source);
        public static TClass FromJson<TClass>(this string source) => JsonUtility.FromJson<TClass>(source);

        public static Vector3 ToVector3(this Vector2 source) => source;
        public static Vector2 ToVector2(this Vector3 source) => source;

        /// <summary>
        /// Checks if a given value falls within the inclusive range defined by this Vector2Int.
        /// </summary>
        /// <param name="source">The Vector2Int representing the range, where x is the minimum and y is the maximum.</param>
        /// <param name="value">The value to check against the range.</param>
        /// <returns>True if the value is within the range (inclusive), otherwise false.</returns>
        public static bool InRange(this Vector2Int source, int value) => 
            value >= source.x && value <= source.y;

        public static void SetPositions(this LineRenderer source, Vector2[] points)
        {
            Vector3[] positions = points
                .Select(p => p.ToVector3())
                .ToArray();
            
            source.SetPositions(positions);
        }

        public static bool IsPlayer(this Component source) => 
            source.CompareTag(Constants.PlayerTag);
    }
}