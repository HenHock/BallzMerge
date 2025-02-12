using Project.Extensions;
using Project.Infrastructure.BootStateMachine;
using Project.Infrastructure.BootStateMachine.StateFactory;
using Project.Infrastructure.BootStateMachine.States;
using Zenject;
using UnityEngine;
using ILogger = Project.Infrastructure.Logger.ILogger;

namespace Project.Infrastructure
{
    /// <summary>
    /// Class to initialize the game state machine and start the game.
    /// </summary>
    public class GameBootstrapper : MonoBehaviour, ILogger
    {
        public Color DefaultColor => Color.yellow;

        private IStateFactory _stateFactory;
        private IGameStateMachine _gameStateMachine;

        [Inject]
        private void Construct(IStateFactory stateFactory, IGameStateMachine stateMachine)
        {
            _stateFactory = stateFactory;
            _gameStateMachine = stateMachine;
        }

        private void Start()
        {
            DontDestroyOnLoad(this);

            _gameStateMachine.RegisterState(_stateFactory.Create<BootstrapState>());
            _gameStateMachine.RegisterState(_stateFactory.Create<LoadGameSceneState>());
            _gameStateMachine.RegisterState(_stateFactory.Create<StartGameRoundState>());
            _gameStateMachine.RegisterState(_stateFactory.Create<LoopGameRoundState>());
            _gameStateMachine.RegisterState(_stateFactory.Create<FinishGameRoundState>());
            _gameStateMachine.RegisterState(_stateFactory.Create<GameOverState>());

            this.Log("Initialized GameStateMachine");

            _gameStateMachine.Enter<BootstrapState>();
        }
    }
}