using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProjectPresenter : MonoBehaviour, IProjectPresenter
{
    [SerializeField] private Animator _animator;
    private const string IsLoadingBool = "IsLoading";

    public event Action onInputLoadDatabase;
    public event Action onInputLoadData;
    public event Action onInputLogIn;
    public event Action onInputSaveData;

    private void Awake()
    {
        SceneManager.sceneLoaded += InputLoadScene;
        SceneManager.sceneUnloaded += InputUnloadScene;
    }
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= InputLoadScene;
        SceneManager.sceneUnloaded -= InputUnloadScene;
    }
    private void Start()
    {
        onInputLogIn?.Invoke();
    }
    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
            onInputSaveData?.Invoke();
    }

    private void InputLoadScene(Scene scene, LoadSceneMode loadSceneMode)
    {
        onInputLoadDatabase?.Invoke();

        onInputLoadData?.Invoke();
        _animator.SetBool(IsLoadingBool, false);
    }

    private void InputUnloadScene(Scene scene)
    {
        onInputSaveData?.Invoke();
        _animator.SetBool(IsLoadingBool, true);
    }
}