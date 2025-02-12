using Project.Services.GameSpeed;
using TMPro;
using UniRx;
using Zenject;
using UnityEngine;
using UnityEngine.UI;

namespace Project.UI
{
    public class TimeScaleButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private TextMeshProUGUI buttonTextTMP;
        
        private IGameSpeedService _gameSpeedService;
        
        [Inject]
        private void Construct(IGameSpeedService gameSpeedService) => 
            _gameSpeedService = gameSpeedService;

        private void Start()
        {
            button.OnClickAsObservable()
                .Subscribe(_ => SetSpeed(_gameSpeedService.CurrentSpeed == 5 ? 1 : 5))
                .AddTo(this);
        }

        private void SetSpeed(float speed)
        {
            _gameSpeedService.ChangeSpeed(speed);
            buttonTextTMP.text = speed == 5 ? "x1" : "x5";
        }
    }
}