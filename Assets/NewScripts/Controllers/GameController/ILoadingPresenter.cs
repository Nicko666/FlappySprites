using UnityEngine.SceneManagement;

public interface ILoadingPresenter
{
    void SetLoaded(Scene scene, LoadSceneMode sceneMode);
    void SetUnloaded(Scene scene);
}
