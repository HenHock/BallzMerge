using Project.Infrastructure.BootStateMachine.States.Interfaces;
using Project.Infrastructure.Services.Input;
using Project.Logic.LevelFactory;

namespace Project.Infrastructure.BootStateMachine.States
{
    public class StartGameRoundState : IState
    {
        private readonly ILevelFactory _levelFactory;
        private readonly IInputService _inputService;
        private readonly IGameStateMachine _stateMachine;

        public StartGameRoundState(IGameStateMachine stateMachine, IInputService inputService)
        {
            _stateMachine = stateMachine;
            _inputService = inputService;
        }

        public void Enter()
        {
            
        }

        public void Next()
        {

        }
    }
}