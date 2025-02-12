using UnityEngine;

namespace Project.Services.AudioPlayer
{
    [CreateAssetMenu(menuName = "Configs/AudioConfig", fileName = "AudioConfig")]
    public class AudioConfig : ScriptableObject
    {
        public AudioClip BallHitClip;
        public AudioClip DestroyBlockClip;
    }
}