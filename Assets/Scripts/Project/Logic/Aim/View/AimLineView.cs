using Project.Extensions;
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
        }

        private void LateUpdate() => 
            lineRenderer.SetPositions(_aimService.CalculateAimPoints());
    }
}