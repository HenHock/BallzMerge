using UnityEngine;

namespace Project.Logic.Aim
{
    public interface IAimService
    {
        void Initialize();
        Vector2[] CalculateAimPoints();
    }
}