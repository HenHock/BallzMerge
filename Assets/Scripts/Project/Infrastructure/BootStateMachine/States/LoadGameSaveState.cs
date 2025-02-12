using Project.Infrastructure.BootStateMachine.States.Interfaces;
using Project.Infrastructure.Services.SaveSystem;

namespace Project.Infrastructure.BootStateMachine.States
{
    /// <summary>
    /// State to load player saves.
    /// </summary>
    public class LoadGameSaveState : IState
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly ISaveLoadService _saveLoadService;

        public LoadGameSaveState(IGameStateMachine stateMachine, ISaveLoadService saveLoadService)
        {
            _stateMachine = stateMachine;
            _saveLoadService = saveLoadService;
        }

        public async void Enter()
        {
            await _saveLoadService.Load();
            Next();
        }

        public void Next() => _stateMachine.Enter<LoadGameSceneState>();
    }
}