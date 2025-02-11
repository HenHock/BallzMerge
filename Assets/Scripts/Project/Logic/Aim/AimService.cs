using Project.Extensions;
using Project.Logic.LevelFactory;
using Project.Infrastructure.Services.Input;
using Project.Logic.Aim.Data;
using UniRx;
using UnityEngine;
using Zenject;

namespace Project.Logic.Aim
{
    public class AimService : IAimService
    {
        public bool IsEnabled { get; private set; }
        public ReactiveCommand<bool> OnEnabledStatusChanged { get; } = new();

        private readonly IInputService _inputService;
        private readonly ILevelFactory _levelFactory;
        private readonly AimConfig _aimConfig;

        private Camera _camera;

        public AimService(IInputService inputService, ILevelFactory levelFactory, AimConfig aimConfig)
        {
            _aimConfig = aimConfig;
            _inputService = inputService;
            _levelFactory = levelFactory;
        }

        public void Initialize()
        {
            _camera = Camera.main;
        }

        public void SetEnable(bool isEnabled)
        {
            IsEnabled = isEnabled;
            OnEnabledStatusChanged?.Execute(isEnabled);
        }

        public Vector2[] CalculateAimPoints()
        {
            Vector2 startPoint = _levelFactory.PlayerTransform.position;
            Vector2 direction = GetDirectionToMouse(startPoint).normalized;
            Vector2 endPoint = startPoint + direction * _aimConfig.MaxDistance;
            Vector2 middlePoint = endPoint;

            RaycastHit2D raycastHit2D = Physics2D.Raycast(startPoint, direction, _aimConfig.MaxDistance, _aimConfig.HitLayerMask);
            if (raycastHit2D.transform != null)
            {
                middlePoint = raycastHit2D.point;
                endPoint = middlePoint + MathExtensions.CalculateReflectDirection( startPoint, middlePoint) * _aimConfig.MaxDistance / 2;
            }

            return new[] { startPoint, middlePoint, endPoint };
        }

        private Vector2 GetDirectionToMouse(Vector2 startPoint) =>
            _camera.ScreenToWorldPoint(_inputService.MousePosition).ToVector2() - startPoint;
    }
}