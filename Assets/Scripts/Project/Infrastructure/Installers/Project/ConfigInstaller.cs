using Project.Extensions;
using Project.Logic.Aim;
using Project.Logic.LevelFactory.Data;
using UnityEngine;
using Zenject;
using ILogger = Project.Infrastructure.Logger.ILogger;

namespace Project.Infrastructure.Installers.Project
{
    /// <summary>
    /// Class to bind configs in DI container. 
    /// </summary>
    [CreateAssetMenu(fileName = "ConfigInstaller", menuName = "Configs/ConfigInstaller")]
    public class ConfigInstaller : ScriptableObjectInstaller, ILogger
    {
        [SerializeField] private GameConfig gameConfig;
        [SerializeField] private LevelConfig levelConfig;
        [SerializeField] private AimConfig aimConfig;
        
        public Color DefaultColor => Color.green;

        public override void InstallBindings()
        {
            this.Log("Start bind configs");

            Container.BindInstances(gameConfig, levelConfig, aimConfig);

            this.Log("Completed bind configs");
        }
    }
}