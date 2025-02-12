using Project.Infrastructure.BootStateMachine.States.Interfaces;
using Project.Services.BlockProvider;
using Project.Services.GameSpeed;
using Project.Services.LevelFactory;
using Project.Services.RoundProgressProvider;
using Project.Services.UIFactory;
using Project.Services.Windows;
using Project.Services.Windows.Data;

namespace Project.Infrastructure.BootStateMachine.States
{
    public class GameOverState : IState
    {
        private readonly IUIFactory _uiFactory;
        private readonly ILevelFactory _levelFactory;
        private readonly IRoundProgressProvider _roundProgressProvider;
        private readonly IWindowService _windowService;
        private readonly IGameSpeedService _speedService;
        private readonly IGameStateMachine _stateMachine;
        private readonly IBlocksProvider _blocksProvider;

        public GameOverState(
            IGameStateMachine stateMachine, 
            IGameSpeedService speedService, 
            IWindowService windowService,
            IUIFactory uiFactory,
            IBlocksProvider blocksProvider,
            ILevelFactory levelFactory,
            IRoundProgressProvider roundProgressProvider)
        {
            _stateMachine = stateMachine;
            _speedService = speedService;
            _windowService = windowService;
            _uiFactory = uiFactory;
            _blocksProvider = blocksProvider;
            _levelFactory = levelFactory;
            _roundProgressProvider = roundProgressProvider;
        }

        public void Enter()
        {
            _speedService.ChangeSpeed(1);
            _windowService.Open(WindowType.GameOver);
        }

        public void Next()
        {
            _uiFactory.Cleanup();
            _levelFactory.Cleanup();
            _blocksProvider.Cleanup();
            _roundProgressProvider.Cleanup();
            
            _stateMachine.Enter<LoadGameSceneState>();
        }
    }
}