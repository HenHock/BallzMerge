using Project.Infrastructure.BootStateMachine.States.Interfaces;
using Project.Infrastructure.Services.Input;

namespace Project.Infrastructure.BootStateMachine.States
{
    public class LoopGameplayState : IState
    {
        private readonly IGameStateMachine _stateMachine;

        public LoopGameplayState(IGameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            
        }

        public void Next()
        {

        }
    }
}