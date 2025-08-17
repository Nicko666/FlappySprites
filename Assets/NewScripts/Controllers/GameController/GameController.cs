using System;
using UnityEngine.SceneManagement;

public class GameController : IDisposable
{
    ILoadingPresenter _loadingPresenter;
    GameSettingsController _gameModels;
    IGamePresenter _gamePresenter;

    public GameController(
        GameSettingsController gameModels,
        ILoadingPresenter loadingPresenter,
        IGamePresenter gamePresenter
        )
    {
        _loadingPresenter = loadingPresenter;
        _gameModels = gameModels;
        _gamePresenter = gamePresenter;

        SceneManager.sceneUnloaded += _loadingPresenter.SetUnloaded;
        SceneManager.sceneLoaded += _loadingPresenter.SetLoaded;

        _gameModels.onPlayerThemesModelChanged += _gamePresenter.OutputPlayerThemesModel;
        _gameModels.onPlayerThemeModelChanged += _gamePresenter.OutputPlayerThemeModel;
        _gameModels.onWorldThemesModelChanged += _gamePresenter.OutputWorldThemesModel;
        _gameModels.onWorldThemeModelChanged += _gamePresenter.OutputWorldThemeModel;
    }
    public void Dispose()
    {
        
    }


}
