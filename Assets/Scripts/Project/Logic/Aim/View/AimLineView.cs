using Project.Extensions;
using UniRx;
using UnityEngine;
using Zenject;

namespace Project.Logic.Aim.View
{
    public class AimLineView : MonoBehaviour
    {
        [SerializeField] private LineRenderer lineRenderer;
        
        private IAimService _aimService;

        [Inject]
        private void Construct(IAimService aimService) => 
            _aimService = aimService;

        private void Start()
        {
            lineRenderer.positionCount = 3;
            
            _aimService.OnEnabledStatusChanged
                .Subscribe(isEnabled => gameObject.SetActive(isEnabled))
                .AddTo(this);
        }

        private void Update() => 
            lineRenderer.SetPositions(_aimService.CalculateAimPoints());
    }
}