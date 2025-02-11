namespace Project.Logic.Player.Movement
{
    public interface IPlayerMovement
    {
        void StopMoving();
        void StartMoving();
        bool IsMoving { get; }
    }
}