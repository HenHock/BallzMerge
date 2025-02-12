using Project.Infrastructure.BootStateMachine.States.Interfaces;

namespace Project.Infrastructure.BootStateMachine.States
{
    public class LoopGameRoundState : IState
    {
        private readonly IGameStateMachine _stateMachine;

        public LoopGameRoundState(IGameStateMachine stateMachine) => 
            _stateMachine = stateMachine;

        public void Enter() {}

        public void Next() => _stateMachine.Enter<FinishGameRoundState>();
    }
}