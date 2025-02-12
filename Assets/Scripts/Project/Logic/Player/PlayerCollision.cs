using Zenject;
using UnityEngine;
using Project.Services.AudioPlayer;

namespace Project.Logic.Player
{
    public class PlayerCollision : MonoBehaviour
    {
        private IAudioPlayer _audioPlayer;

        [Inject]
        private void Construct(IAudioPlayer audioPlayer)
        {
            _audioPlayer = audioPlayer;
        }
        
        private void OnCollisionEnter2D(Collision2D other) => 
            _audioPlayer.PlayBallHit();
    }
}