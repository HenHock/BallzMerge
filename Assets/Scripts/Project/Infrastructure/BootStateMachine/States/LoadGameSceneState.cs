using Project.Infrastructure.BootStateMachine.States.Interfaces;
using Project.Infrastructure.Services.SceneLoader;

namespace Project.Infrastructure.BootStateMachine.States
{
    /// <summary>
    /// State to load gameplay scene
    /// </summary>
    public class LoadGameSceneState : IState
    {
        private readonly GameConfig _gameConfig;
        private readonly ISceneLoader _sceneLoader;
        private readonly IGameStateMachine _stateMachine;

        public LoadGameSceneState(
            IGameStateMachine stateMachine, 
            ISceneLoader sceneLoader, 
            GameConfig gameConfig)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _gameConfig = gameConfig;
        }

        public void Enter() => _sceneLoader.Load(_gameConfig.GameplayScene, Next);

        public void Next() => _stateMachine.Enter<LoopGameplayState>();
    }
}