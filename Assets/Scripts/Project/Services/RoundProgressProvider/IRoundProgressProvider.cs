using UniRx;

namespace Project.Services.RoundProgressProvider
{
    public interface IRoundProgressProvider
    {
        ReactiveProperty<int> CurrentRound { get; }
        void Cleanup();
    }
}