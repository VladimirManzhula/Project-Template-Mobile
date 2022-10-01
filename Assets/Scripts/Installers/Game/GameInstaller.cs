using Ui.Game;
using Ui.Game.Windows;
using Zenject;

namespace Installers.Game
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindManagers();
            BindWindows();
        }

        private void BindManagers()
        { 
            Container.BindInterfacesTo<GameWindowManager>().AsSingle();
        }

        private void BindWindows()
        {
            Container.BindInterfacesAndSelfTo<HudWindow>().AsSingle();
        }
    }
}