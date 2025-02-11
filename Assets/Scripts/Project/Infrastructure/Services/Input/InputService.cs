using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Project.Infrastructure.Services.Input
{
    public sealed class InputService : IInputService
    {
        public Vector2 MousePosition => _gameInputActions.Mouse.Position.ReadValue<Vector2>();
        public ReactiveCommand<Vector2> OnClick { get; }

        private readonly GameInputActions _gameInputActions;
        
        public InputService()
        {
            OnClick = new ReactiveCommand<Vector2>();
            _gameInputActions = new GameInputActions();

            Observable.EveryUpdate()
                .Where(_ => _gameInputActions.Mouse.Click.WasReleasedThisFrame())
                .Subscribe(_ => OnClick?.Execute(MousePosition));
        }

        public void EnableInputs() => _gameInputActions.Enable();

        public void DisableInputs() => _gameInputActions.Disable();
    }
}