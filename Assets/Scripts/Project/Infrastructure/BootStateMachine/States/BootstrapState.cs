using Project.Infrastructure.BootStateMachine.States.Interfaces;

namespace Project.Infrastructure.BootStateMachine.States
{
    /// <summary>
    /// State to initialization all game life services.
    /// </summary>
    public class BootstrapState : IState
    {
        private readonly IGameStateMachine _stateMachine;

        public BootstrapState(IGameStateMachine stateMachine) => 
            _stateMachine = stateMachine;

        public void Enter()
        {
            Next();
        }

        public void Next() => _stateMachine.Enter<LoadGameSaveState>();
    }
}