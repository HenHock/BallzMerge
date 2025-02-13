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
            lineRenderer.positionCount = 0;
            
            _aimService.OnEnabledStatusChanged
                .Subscribe(HandleEnableStatusChanged)
                .AddTo(this);

            _aimService.OnStartAiming
                .Subscribe(_ => lineRenderer.positionCount = 3)
                .AddTo(this);
        }

        private void Update() => 
            lineRenderer.SetPositions(_aimService.CalculateAimPoints());

        private void HandleEnableStatusChanged(bool isEnabled)
        {
            gameObject.SetActive(isEnabled);
            if (!isEnabled) 
                lineRenderer.positionCount = 0;
        }
    }
}