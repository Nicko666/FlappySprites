using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : IDisposable
{
    protected IProjectPresenter _loadingPresenter;
    protected GooglePlayController _googlePlayController = new GooglePlayController();

    public Controller(IProjectPresenter loadingPresenter)
    {
        Application.focusChanged += ChangeFocus;
        SceneManager.sceneLoaded += SceneLoaded;
        SceneManager.sceneUnloaded += SceneUnloaded;

        _loadingPresenter = loadingPresenter;
    }
    public virtual void Dispose()
    {

    }

    private void ChangeFocus(bool value)
    {
        if (!value) SaveData();
        else LoadData();
    }
    private void SceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        LoadData();
        _loadingPresenter.OutputLoading(false);
    }
    private void SceneUnloaded(Scene scene)
    {
        _loadingPresenter.OutputLoading(true);
        SaveData();
    }

    protected virtual void LoadData()
    {
        Application.targetFrameRate = 60;
        _googlePlayController.SetGooglePlayLogIn();
    }
    protected virtual void SaveData() { }
}
