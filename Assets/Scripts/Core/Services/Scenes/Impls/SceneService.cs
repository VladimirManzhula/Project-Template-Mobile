using UnityEngine.SceneManagement;

namespace Core.Services.Scenes.Impls
{
    public class SceneService : ISceneService
    {
        public void LoadScene(ScenePlace scenePlace) => SceneManager.LoadScene(scenePlace.Value);
    }
}