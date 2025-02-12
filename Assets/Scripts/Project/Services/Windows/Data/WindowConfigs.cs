using System;
using UnityEngine;

namespace Project.Services.Windows.Data
{
    [CreateAssetMenu(menuName = "Configs/WindowConfigs", fileName = "WindowConfigs")]
    public class WindowConfigs : ScriptableObject
    {
        public WindowData[] Configs = Array.Empty<WindowData>();
    }
}