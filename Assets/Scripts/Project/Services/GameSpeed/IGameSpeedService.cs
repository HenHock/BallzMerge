namespace Project.Services.GameSpeed
{
    public interface IGameSpeedService
    {
        void ChangeSpeed(float speed);
        float CurrentSpeed { get; }
    }
}