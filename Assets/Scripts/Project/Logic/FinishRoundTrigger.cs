using Project.Extensions;
using Project.Infrastructure.BootStateMachine;
using Project.Infrastructure.BootStateMachine.States;
using Project.Logic.Player.Movement;
using UnityEngine;
using Zenject;

namespace Project.Logic
{
    public class FinishRoundTrigger : MonoBehaviour
    {
        private IGameStateMachine _gameStateMachine;

        [Inject]
        private void Construct(IGameStateMachine gameStateMachine) => 
            _gameStateMachine = gameStateMachine;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.IsPlayer())
            {
                if (other.attachedRigidbody.velocity == Vector2.zero)
                    return;
                
                other.attachedRigidbody
                    .GetComponent<PlayerMovement>()
                    .StopMoving();

                _gameStateMachine.CurrentState.Value.Next();         
            }
        }
    }
}