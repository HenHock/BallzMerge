using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Project.Infrastructure.Services.Input
{
    public sealed class InputService : IInputService
    {
        public ReactiveCommand<Vector2> OnClick { get; }
        public Vector2 MousePosition => _gameInputActions.Mouse.Position.ReadValue<Vector2>();

        private readonly GameInputActions _gameInputActions;
        
        public InputService()
        {
            OnClick = new ReactiveCommand<Vector2>();
            _gameInputActions = new GameInputActions();

            Observable.EveryUpdate()
                .Where(_ => _gameInputActions.Mouse.Click.WasReleasedThisFrame())
                .Where(_ => !IsPointerOverUI())
                .Subscribe(_ => OnClick?.Execute(MousePosition));
        }

        public void EnableInputs() => _gameInputActions.Enable();

        public void DisableInputs() => _gameInputActions.Disable();

        private bool IsPointerOverUI() => 
            _gameInputActions.asset.enabled && EventSystem.current.IsPointerOverGameObject();
    }
}