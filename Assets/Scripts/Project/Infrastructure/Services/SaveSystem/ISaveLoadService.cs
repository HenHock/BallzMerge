using Cysharp.Threading.Tasks;
using Project.Infrastructure.Services.SaveSystem.SaveHandler;

namespace Project.Infrastructure.Services.SaveSystem
{
    public interface ISaveLoadService
    {
        void Save();
        UniTask Load();
        void Cleanup();
        void Register(ISaveHandler saveHandler);
    }
}