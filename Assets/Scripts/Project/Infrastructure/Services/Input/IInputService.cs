using UniRx;
using UnityEngine;

namespace Project.Infrastructure.Services.Input
{
    public interface IInputService
    {
        /// <summary>
        /// Mouse position in screen space
        /// </summary>
        Vector2 MousePosition { get; }
        
        void EnableInputs();
        void DisableInputs();
    }
}