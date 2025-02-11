using TMPro;
using UnityEngine;

namespace Project.Logic.Block
{
    public class BlockView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private TMP_Text NumberTMP;
        
        public void Initialize(int number, Color color)
        {
            spriteRenderer.color = color;
            NumberTMP.text = number.ToString();
        }
    }
}