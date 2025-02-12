using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Services.Windows
{
    public abstract class BaseWindow : MonoBehaviour
    {
        [SerializeField] protected Button closeButton;

        protected virtual void Awake() =>
            closeButton?.OnClickAsObservable()
                .Subscribe(_ => Close());

        public abstract void Open();

        public virtual void Close() => Destroy(gameObject);
    }
}