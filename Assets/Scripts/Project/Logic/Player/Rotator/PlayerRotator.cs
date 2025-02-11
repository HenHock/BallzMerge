using Project.Infrastructure.Services.Input;
using Project.Logic.Aim;
using UniRx;
using UnityEngine;
using Zenject;

namespace Project.Logic.Player.Rotator
{
    public class PlayerRotator : MonoBehaviour
    {
        private Camera _camera;
        private IAimService _aimService;
        private IInputService _inputService;
        private Vector2 _cachedMousePosition;

        [Inject]
        private void Construct(IInputService inputService, IAimService aimService)
        {
            _inputService = inputService;
            _aimService = aimService;
        }

        private void Start()
        {
            _camera = Camera.main;
            _cachedMousePosition = _inputService.MousePosition;
            
            _aimService.OnEnabledStatusChanged
                .Subscribe(SetEnabled)
                .AddTo(this);
        }

        private void Update()
        {
            if (IsMousePositionChanged()) 
                RotateToMouse();
        }

        private void RotateToMouse()
        {
            _cachedMousePosition = _inputService.MousePosition;
            Vector3 worldMousePosition = _camera.ScreenToWorldPoint(_inputService.MousePosition);
            Vector2 direction = (worldMousePosition - transform.position).normalized;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
        }

        private void SetEnabled(bool isEnabled)
        {
            enabled = isEnabled;
            
            if (enabled) 
                RotateToMouse();
        }

        private bool IsMousePositionChanged() => _inputService.MousePosition != _cachedMousePosition;
    }
}