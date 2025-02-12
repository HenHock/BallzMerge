namespace Project.Services.AudioPlayer
{
    public interface IAudioPlayer
    {
        void Initialize();
        void PlayBallHit();
        void PlayDestroyBlock();
    }
}