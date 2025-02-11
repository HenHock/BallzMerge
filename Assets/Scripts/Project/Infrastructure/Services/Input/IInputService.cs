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
        
        /// <summary>
        /// Invoked when player clicked
        /// </summary>
        /// <param name="MousePosition">Mouse position in screen space</param>
        ReactiveCommand<Vector2> OnClick { get; }

        void EnableInputs();
        void DisableInputs();
    }
}