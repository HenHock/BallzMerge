using Project.Balance;
using Project.Extensions;
using Project.Logic.Aim.Data;
using Project.Logic.Block.Data;
using Project.Logic.Player.Data;
using Project.Services.Grid.Data;
using Project.Services.LevelFactory.Data;
using Project.Services.Windows.Data;
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
        [SerializeField] private PlayerConfig playerConfig;
        [SerializeField] private TileMapConfig tileMapConfig;
        [SerializeField] private RoundDropConfigs roundDropConfigs;
        [SerializeField] private RoundNumberConfigs roundNumberConfigs;
        [SerializeField] private BlockColorConfig blockColorConfig;
        [SerializeField] private WindowConfigs windowConfigs;
        
        public Color DefaultColor => Color.green;

        public override void InstallBindings()
        {
            this.Log("Start bind configs");

            Container.BindInstances
            (
                gameConfig, levelConfig, aimConfig, playerConfig, tileMapConfig,
                roundDropConfigs, roundNumberConfigs, blockColorConfig, windowConfigs
            );

            this.Log("Completed bind configs");
        }
    }
}