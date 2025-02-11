using Project.Infrastructure.BootStateMachine.States.Interfaces;
using Project.Infrastructure.Services.Input;
using Project.Infrastructure.Services.SceneLoader;
using Project.Logic.Aim;
using Project.Logic.Grid;
using Project.Logic.LevelFactory;

namespace Project.Infrastructure.BootStateMachine.States
{
    /// <summary>
    /// State to load game scene
    /// </summary>
    public class LoadGameSceneState : IState
    {
        private readonly GameConfig _gameConfig;
        private readonly ISceneLoader _sceneLoader;
        private readonly IGameStateMachine _stateMachine;
        private readonly ILevelFactory _levelFactory;
        private readonly IAimService _aimService;
        private readonly ITileGridMap _tileGridMap;

        public LoadGameSceneState(
            IGameStateMachine stateMachine, 
            ISceneLoader sceneLoader, 
            GameConfig gameConfig, 
            ILevelFactory levelFactory, 
            IAimService aimService,
            ITileGridMap tileGridMap)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _gameConfig = gameConfig;
            _levelFactory = levelFactory;
            _aimService = aimService;
            _tileGridMap = tileGridMap;
        }

        public void Enter() => _sceneLoader.Load(_gameConfig.GameplayScene, OnLoadedScene);

        public void Next() => _stateMachine.Enter<StartGameRoundState>();

        private void OnLoadedScene()
        {
            _aimService.Initialize();
            _tileGridMap.Initialize();
            
            CreateLevel();
            Next();
        }

        private void CreateLevel()
        {
            _levelFactory.CreatePlayer();
            _levelFactory.CreateBlocks();
        }
    }
}