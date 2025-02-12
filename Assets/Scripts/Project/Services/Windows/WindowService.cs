using Project.Services.Windows.Data;
using UniRx;

namespace Project.Services.Windows
{
    public sealed class WindowService : IWindowService
    {
        public ReactiveProperty<BaseWindow> ActiveWindow { get; } = new();

        private readonly UIFactory.UIFactory _uiFactory;
        
        public WindowService(UIFactory.UIFactory uiFactory) => 
            _uiFactory = uiFactory;

        public void Open(WindowType windowType)
        {
            if (ActiveWindow.Value != null) 
                ActiveWindow.Value.Close();

            ActiveWindow.Value = _uiFactory.CreateWindow(windowType);
            ActiveWindow.Value.Open();
        }
    }
}