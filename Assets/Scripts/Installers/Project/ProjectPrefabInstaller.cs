using UnityEngine;
using Zenject;

namespace Installers.Project
{
    [CreateAssetMenu(menuName = "Installers/ProjectPrefabInstaller", fileName = "ProjectPrefabInstaller")]
    public class ProjectPrefabInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private Canvas canvas;

        public override void InstallBindings()
        {
            Container.InstantiatePrefabForComponent<Canvas>(canvas);
        }
    }
}