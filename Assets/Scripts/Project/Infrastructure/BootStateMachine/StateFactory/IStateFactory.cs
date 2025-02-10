using Project.Infrastructure.BootStateMachine.States.Interfaces;

namespace Project.Infrastructure.BootStateMachine.StateFactory
{
    public interface IStateFactory
    {
        TState Create<TState>() where TState : IExitableState;
    }
}