using Project.Infrastructure.BootStateMachine.States.Interfaces;
using Project.Infrastructure.Services.Input;
using Project.Logic;
using Project.Logic.Aim;
using Project.Services.LevelFactory;
using Project.Services.RoundProgressProvider;
using UniRx;

namespace Project.Infrastructure.BootStateMachine.States
{
    public class StartGameRoundState : IState
    {
        private readonly IAimService _aimService;
        private readonly ILevelFactory _levelFactory;
        private readonly IInputService _inputService;
        private readonly IGameStateMachine _stateMachine;
        private readonly IRoundProgressProvider _roundProgress;

        public StartGameRoundState(
            IGameStateMachine stateMachine, 
            IInputService inputService, 
            IAimService aimService, 
            ILevelFactory levelFactory, 
            IRoundProgressProvider roundProgress)
        {
            _stateMachine = stateMachine;
            _inputService = inputService;
            _aimService = aimService;
            _levelFactory = levelFactory;
            _roundProgress = roundProgress;

            Initialize();
        }

        public void Initialize() =>
            _inputService.OnClick
                .Subscribe(_ => Next());

        public void Enter()
        {
            _roundProgress.CurrentRound.Value++;

            _levelFactory.CreateBlocks(_roundProgress.CurrentRound.Value);
            _inputService.EnableInputs();
            _aimService.SetEnable(true);
        }

        public void Exit()
        {
            _inputService.DisableInputs();
            _aimService.SetEnable(false);
        }

        public void Next() => _stateMachine.Enter<LoopGameRoundState>();
    }
}