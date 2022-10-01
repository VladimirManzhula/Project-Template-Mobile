using Ui.Splash;
using Ui.Splash.Windows;
using Zenject;

namespace Installers.Splash
{
    public class SplashInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindManagers();
            BindWindows();
        }

        private void BindManagers()
        {
            Container.BindInterfacesTo<SplashWindowManager>().AsSingle();
        }

        private void BindWindows()
        {
            Container.BindInterfacesAndSelfTo<SplashScreenWindow>().AsSingle();
        }
    }
}