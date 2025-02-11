using UnityEngine;

namespace Project.Infrastructure.Services.Input
{
    public sealed class InputService : IInputService
    {
        public Vector2 MousePosition => _gameInputActions.Mouse.Position.ReadValue<Vector2>();

        private readonly GameInputActions _gameInputActions;
        
        public InputService()
        {
            _gameInputActions = new GameInputActions();
        }

        public void EnableInputs() => _gameInputActions.Enable();

        public void DisableInputs() => _gameInputActions.Disable();
    }
}