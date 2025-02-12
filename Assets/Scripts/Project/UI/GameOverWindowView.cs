using Project.Infrastructure.BootStateMachine;
using Project.Infrastructure.Services.SaveSystem;
using Project.Services.Windows;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Project.UI
{
    public class GameOverWindowView : BaseWindow
    {
        [SerializeField] private Button nextButton;
        [SerializeField] private Button saveButtons;
        
        private ISaveLoadService _saveLoadService;
        private IGameStateMachine _gameStateMachine;

        [Inject]
        private void Construct(ISaveLoadService saveLoadService, IGameStateMachine gameStateMachine)
        {
            _saveLoadService = saveLoadService;
            _gameStateMachine = gameStateMachine;
        }
        
        public override void Open()
        {
            nextButton.onClick.AddListener(Reload);
            saveButtons.onClick.AddListener(Save);
        }

        private void Save() => _saveLoadService.Save();

        private void Reload() => _gameStateMachine.CurrentState.Value.Next();
    }
}