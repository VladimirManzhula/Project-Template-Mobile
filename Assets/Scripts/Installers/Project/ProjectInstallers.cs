using Core.Services.Scenes.Impls;
using UnityEngine;
using Zenject;

namespace Installers.Project
{
    public class ProjectInstallers : MonoInstaller
    {
        public override void InstallBindings()
        {
            SetSettings();
            BindServices();
        }

        private void SetSettings()
        {
            Application.targetFrameRate = 60;
            SignalBusInstaller.Install(Container); 
        }

        private void BindServices()
        {
            Container.BindInterfacesTo<SceneService>().AsSingle();
        }
    }
}