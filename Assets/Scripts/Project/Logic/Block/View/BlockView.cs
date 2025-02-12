using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Project.Logic.Block.View
{
    public class BlockView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private TMP_Text NumberTMP;
        
        public void Initialize(int number, Color color)
        {
            spriteRenderer.color = color;
            NumberTMP.text = number.ToString();

            PlayAppearTween();
        }

        private void PlayAppearTween()
        {
            Vector2 scale = transform.localScale;
            transform.localScale = Vector3.zero;
            
            transform.DOScale(scale, 0.5f)
                .SetEase(Ease.InOutExpo)
                .Play();
        }

        public void PlayDistroyTween() =>
            transform.DOScale(Vector2.zero, 0.5f)
                .SetEase(Ease.InBounce)
                .OnComplete(() => Destroy(gameObject))
                .Play();
    }
}