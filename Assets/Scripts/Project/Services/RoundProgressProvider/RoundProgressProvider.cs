using Project.Infrastructure.Services.SaveSystem.Data;
using Project.Infrastructure.Services.SaveSystem.SaveHandler;
using UniRx;

namespace Project.Services.RoundProgressProvider
{
    public class RoundProgressProvider : SaveHandler, IRoundProgressProvider
    {
        public ReactiveProperty<int> CurrentRound { get; } = new();
        
        public void Cleanup() => CurrentRound.Value = 0;

        public override void LoadProgress(GameProgress progress){}

        public override void UpdateProgress(GameProgress progress) => 
            progress.BestScore = CurrentRound.Value;
    }
}