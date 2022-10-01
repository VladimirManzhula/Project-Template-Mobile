using SimpleUi;
using Ui.Game.Hud;
using UnityEngine;
using Zenject;

namespace Installers.Game
{
    [CreateAssetMenu(menuName = "Installers/GameUiInstaller", fileName = "GameUiInstaller")]
    public class GameUiInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private Canvas canvas;
        [SerializeField] private HudView hudView;
        

        public override void InstallBindings()
        {
            var canvasInstance = Container.InstantiatePrefabForComponent<Canvas>(canvas);
            var canvasTransform = canvasInstance.transform;
            
            Container.BindUiView<HudController, HudView>(hudView, canvasTransform);
        }
    }
}