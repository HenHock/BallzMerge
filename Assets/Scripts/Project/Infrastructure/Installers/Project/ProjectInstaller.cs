using Project.Extensions;
using Project.Infrastructure.BootStateMachine;
using Project.Infrastructure.BootStateMachine.StateFactory;
using Project.Infrastructure.Services.Input;
using Project.Infrastructure.Services.SaveSystem;
using Project.Infrastructure.Services.SaveSystem.PersistentProgressService;
using Project.Infrastructure.Services.SceneLoader;
using Project.Logic.Aim;
using Project.Logic.Block;
using Project.Logic.BlockProvider;
using Project.Logic.Grid;
using Project.Logic.LevelFactory;
using UnityEngine;
using Zenject;
using ILogger = Project.Infrastructure.Logger.ILogger;

namespace Project.Infrastructure.Installers.Project
{
    /// <summary>
    /// Class to bind services that will live throughout the entire game life.
    /// </summary>
    public class ProjectInstaller : MonoInstaller, ILogger
    {
        public Color DefaultColor => Color.green;

        public override void InstallBindings()
        {
            this.Log("Start bind game services");

            BindSceneLoader();
            BindStateFactory();
            BindGameStateMachine();
            BindInputService();
            BindLevelFactory();
            BindAimService();
            BindTileGridMap();
            BindBlocksProvider();
            BindSaveLoadService();
            BindPersistentProgress();

            this.Log("Completed bind game services");
        }

        private void BindInputService() => Container
            .BindInterfacesAndSelfTo<InputService>()
            .AsSingle();

        private void BindSceneLoader() => Container
            .BindInterfacesAndSelfTo<SceneLoader>()
            .AsSingle();

        private void BindStateFactory() => Container
            .BindInterfacesAndSelfTo<StateFactory>()
            .AsSingle();

        private void BindGameStateMachine() => Container
            .BindInterfacesAndSelfTo<GameStateMachine>()
            .AsSingle();

        private void BindLevelFactory() => Container
            .BindInterfacesAndSelfTo<LevelFactory>()
            .AsSingle();

        private void BindAimService() => Container
            .BindInterfacesAndSelfTo<AimService>()
            .AsSingle();

        private void BindTileGridMap() => Container
            .BindInterfacesAndSelfTo<TileGridMap>()
            .AsSingle();

        private void BindBlocksProvider() => Container
            .BindInterfacesAndSelfTo<BlocksProvider>()
            .AsSingle();

        private void BindSaveLoadService() => Container
            .BindInterfacesAndSelfTo<SaveLoadService>()
            .AsSingle();

        private void BindPersistentProgress() => Container
            .BindInterfacesAndSelfTo<PersistentProgressService>()
            .AsSingle();
    }
}