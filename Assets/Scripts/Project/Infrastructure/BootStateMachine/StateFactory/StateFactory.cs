using Project.Infrastructure.BootStateMachine.States.Interfaces;
using Zenject;

namespace Project.Infrastructure.BootStateMachine.StateFactory
{
    public class StateFactory : IStateFactory
    {
        private readonly DiContainer _container;

        public StateFactory(DiContainer container) => 
            _container = container;

        public TState Create<TState>() where TState : IExitableState =>
            _container.Instantiate<TState>();
    }
}