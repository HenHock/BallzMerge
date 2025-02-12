using Project.Logic;
using Project.Services.RoundProgressProvider;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace Project.UI
{
    public class RoundProgressView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI roundProgressTMP;
        
        private IRoundProgressProvider _progressProvider;

        [Inject]
        private void Construct(IRoundProgressProvider roundProgressProvider) => 
            _progressProvider = roundProgressProvider;

        private void Start()
        {
            _progressProvider.CurrentRound
                .Subscribe(progress => roundProgressTMP.text = $"Move: {progress}")
                .AddTo(this);
        }
    }
}