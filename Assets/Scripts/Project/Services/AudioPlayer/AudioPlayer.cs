using UnityEngine;

namespace Project.Services.AudioPlayer
{
    public class AudioPlayer : IAudioPlayer
    {
        private AudioSource _audioSource;
        private readonly AudioConfig _audioConfig;

        public AudioPlayer(AudioConfig audioConfig) => 
            _audioConfig = audioConfig;

        public void Initialize() => 
            _audioSource = new GameObject("AudioSource")
                .AddComponent<AudioSource>();

        public void PlayBallHit() => 
            _audioSource.PlayOneShot(_audioConfig.BallHitClip);

        public void PlayDestroyBlock() =>
            _audioSource.PlayOneShot(_audioConfig.DestroyBlockClip);
    }
}