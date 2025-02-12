using System.Linq;
using Project.Services.Windows;
using Project.Services.Windows.Data;
using UnityEngine;
using Zenject;

namespace Project.Services.UIFactory
{
    public class UIFactory : IUIFactory
    {
        private const string UIRootPath = "UIRoot";
        
        private Transform _uiRoot;
        private readonly WindowConfigs _windowConfigs;
        private readonly IInstantiator _instantiator;

        public UIFactory(IInstantiator instantiator, WindowConfigs windowConfigs)
        {
            _instantiator = instantiator;
            _windowConfigs = windowConfigs;
        }

        public void CreateUIRoot() => 
            _uiRoot = _instantiator.InstantiatePrefabResource(UIRootPath).transform;

        public void Cleanup() => 
            Object.Destroy(_uiRoot.gameObject);

        public BaseWindow CreateWindow(WindowType windowType)
        {
            var windowConfig = GetWindowConfig(windowType);
            return InstantiateUIPrefab(windowConfig.Prefab, _uiRoot);
        }

        private TComponent InstantiateUIPrefab<TComponent>(TComponent prefab, Transform parent) where TComponent : Component
        {
            var instance = _instantiator.InstantiatePrefabForComponent<TComponent>(prefab);
            instance.transform.SetParent(parent, false);
            instance.transform.localScale = Vector3.one;
            
            return instance;
        }

        private WindowData GetWindowConfig(WindowType windowType) => 
            _windowConfigs.Configs.FirstOrDefault(config => config.Type == windowType);
    }
}