using Project.Services.Windows.Data;

namespace Project.Services.Windows
{
    public interface IWindowService
    {
        void Open(WindowType windowType);
    }
}