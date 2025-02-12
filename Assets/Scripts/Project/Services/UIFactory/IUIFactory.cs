using Project.Services.Windows;
using Project.Services.Windows.Data;

namespace Project.Services.UIFactory
{
    public interface IUIFactory
    {
        BaseWindow CreateWindow(WindowType windowType);
        void CreateUIRoot();
        void Cleanup();
    }
}