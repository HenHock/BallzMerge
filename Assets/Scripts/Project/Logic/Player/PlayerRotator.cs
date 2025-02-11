using Project.Extensions;
using Zenject;
using UnityEngine;
using Project.Infrastructure.Services.Input;

namespace Project.Logic.Player
{
    public class PlayerRotator : MonoBehaviour
    {
        private Camera _camera;
        private IInputService _inputService;
        private Vector2 _cachedMousePosition;

        [Inject]
        private void Construct(IInputService inputService) => 
            _inputService = inputService;

        private void Start()
        {
            _camera = Camera.main;
            _cachedMousePosition = _inputService.MousePosition;
        }

        private void Update()
        {
            if (IsMousePositionChanged())
            {
                Vector3 worldMousePosition = _camera.ScreenToWorldPoint(_inputService.MousePosition);
                Vector2 direction = (worldMousePosition - transform.position).normalized;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
                _cachedMousePosition = _inputService.MousePosition;
            }
        }

        private bool IsMousePositionChanged() => _inputService.MousePosition != _cachedMousePosition;
    }
}