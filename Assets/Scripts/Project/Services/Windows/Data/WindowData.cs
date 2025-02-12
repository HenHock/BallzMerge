using System;

namespace Project.Services.Windows.Data
{
    [Serializable]
    public struct WindowData
    {
        public WindowType Type;
        public BaseWindow Prefab;
    }
}