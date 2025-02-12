using UnityEngine;

namespace Project.Services.GameSpeed
{
    public class GameSpeedService : IGameSpeedService
    {
        public float CurrentSpeed => Time.timeScale;

        public void ChangeSpeed(float speed) => 
            Time.timeScale = speed;
    }
}