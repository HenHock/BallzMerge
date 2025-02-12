using TMPro;
using Zenject;
using UnityEngine;
using Project.Infrastructure.Services.SaveSystem.PersistentProgressService;

namespace Project.UI
{
    public class BestScoreView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI bestScoreTMP;
        
        private IPersistentProgressService _progressService;

        [Inject]
        private void Construct(IPersistentProgressService progressService) => 
            _progressService = progressService;

        private void Start() => 
            bestScoreTMP.text = $"Best Score: {_progressService.Progress.BestScore}";
    }
}