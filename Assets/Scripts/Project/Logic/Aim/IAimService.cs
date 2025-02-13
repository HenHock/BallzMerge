using UniRx;
using UnityEngine;

namespace Project.Logic.Aim
{
    public interface IAimService
    {
        void Initialize();
        Vector2[] CalculateAimPoints();
        void SetEnable(bool isEnabled);
        ReactiveCommand<bool> OnEnabledStatusChanged { get; }
        bool IsEnabled { get; }
        ReactiveCommand OnStartAiming { get; }
    }
}