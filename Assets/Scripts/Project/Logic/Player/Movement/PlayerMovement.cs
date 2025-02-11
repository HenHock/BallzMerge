using NaughtyAttributes;
using Project.Infrastructure.Services.Input;
using Project.Logic.Player.Data;
using UniRx;
using UnityEngine;
using Zenject;

namespace Project.Logic.Player.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour, IPlayerMovement
    {
        [ShowNativeProperty]
        public float Speed => _playerConfig?.Speed ?? 0f;

        public bool IsMoving => _rigidbody2D.velocity.sqrMagnitude > 0;

        private PlayerConfig _playerConfig;
        private Rigidbody2D _rigidbody2D;
        private IInputService _inputService;

        [Inject]
        private void Construct(PlayerConfig playerConfig, IInputService inputService)
        {
            _inputService = inputService;
            _playerConfig = playerConfig;
        }

        private void Awake() => 
            _rigidbody2D = GetComponent<Rigidbody2D>();

        private void Start()
        {
            _inputService.OnClick
                .Subscribe(_ => StartMoving())
                .AddTo(this);
        }

        public void StopMoving() => 
            _rigidbody2D.velocity = Vector2.zero;

        public void StartMoving() => 
            _rigidbody2D.velocity = Speed * transform.up;
    }
}