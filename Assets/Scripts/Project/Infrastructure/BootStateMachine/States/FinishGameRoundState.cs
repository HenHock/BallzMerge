using Project.Infrastructure.BootStateMachine.States.Interfaces;

namespace Project.Infrastructure.BootStateMachine.States
{
    public class FinishGameRoundState : IState
    {
        private readonly IGameStateMachine _stateMachine;

        public FinishGameRoundState(IGameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            Next();
        }

        public void Next() => _stateMachine.Enter<StartGameRoundState>();
    }
}