using SimpleUi.Signals;
using Ui.Splash.Windows;
using Zenject;

namespace Ui.Splash
{
    public class SplashWindowManager : IInitializable
    {
        private readonly SignalBus _signalBus;

        public SplashWindowManager(
            SignalBus signalBus
        )
        {
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            _signalBus.OpenWindow<SplashScreenWindow>();
        }
    }
}