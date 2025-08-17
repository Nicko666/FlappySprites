using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingPresenter : MonoBehaviour, ILoadingPresenter
{
    [SerializeField] private float _duration;
    [SerializeField] private Animator _animator;
    private const string IsLoadingBool = "IsLoading";

    public void SetLoaded(Scene scene, LoadSceneMode sceneMode) =>
        _animator.SetBool(IsLoadingBool, false);

    public void SetUnloaded(Scene scene) =>
        _animator.SetBool(IsLoadingBool, true);

    private void Start()
    {
        _animator.speed = 1/_duration;
    }
}