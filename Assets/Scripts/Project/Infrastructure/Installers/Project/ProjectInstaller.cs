using Project.Extensions;
using Project.Infrastructure.BootStateMachine;
using Project.Infrastructure.BootStateMachine.StateFactory;
using Project.Infrastructure.Services.Input;
using Project.Infrastructure.Services.SaveSystem;
using Project.Infrastructure.Services.SaveSystem.PersistentProgressService;
using Project.Infrastructure.Services.SceneLoader;
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

            this.Log("Completed bind game services");
        }

        private void BindSceneLoader() => Container
            .BindInterfacesAndSelfTo<SceneLoader>()
            .AsSingle();

        private void BindStateFactory() => Container
            .BindInterfacesAndSelfTo<StateFactory>()
            .AsSingle();

        private void BindGameStateMachine() => Container
            .BindInterfacesAndSelfTo<GameStateMachine>()
            .AsSingle();
    }
}