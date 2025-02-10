namespace Project.Infrastructure.BootStateMachine.States.Interfaces
{
    public interface IExitableState
    {
        void Exit() {}
        void Next();
    }
}