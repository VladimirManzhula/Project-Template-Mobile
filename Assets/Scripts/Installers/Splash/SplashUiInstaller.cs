using SimpleUi;
using Ui.Splash.SplashScreen;
using UnityEngine;
using Zenject;

namespace Installers.Splash
{
    [CreateAssetMenu(menuName = "Installers/SplashPrefabInstaller", fileName = "SplashPrefabInstaller")]
    public class SplashUiInstaller : ScriptableObjectInstaller
    {
        [Header("Canvas")]
        [SerializeField] private Canvas canvas;

        [Space] [Header("Views")] [SerializeField]
        private SplashScreenView splashScreenView;

        public override void InstallBindings()
        {
            var canvasInstance = Container.InstantiatePrefabForComponent<Canvas>(canvas);
            var canvasTransform = canvasInstance.transform;
            
            Container.BindUiView<SplashScreenController, SplashScreenView>(splashScreenView, canvasTransform);
        }
    }
}