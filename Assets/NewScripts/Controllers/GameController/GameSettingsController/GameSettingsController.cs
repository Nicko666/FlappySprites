using System;
using UnityEngine.SceneManagement;

public class GameSettingsController
{
    private GameData _gameData;
    private SaveData _saveData = new();
    private SelectionController<PlayerThemeModel> _playerThemesController = new();
    private SelectionController<WorldThemeModel> _worldThemesController = new();
    
    internal event Action<PlayerThemeModel[]> onPlayerThemesModelChanged
    {
        add => _playerThemesController.onValuesChanged += value;
        remove => _playerThemesController.onValuesChanged -= value;
    }
    internal event Action<PlayerThemeModel> onPlayerThemeModelChanged
    {
        add => _playerThemesController.onValueChanged += value;
        remove => _playerThemesController.onValueChanged -= value;
    }

    internal event Action<WorldThemeModel[]> onWorldThemesModelChanged
    {
        add => _worldThemesController.onValuesChanged += value;
        remove => _worldThemesController.onValuesChanged -= value;
    }
    internal event Action<WorldThemeModel> onWorldThemeModelChanged
    {
        add => _worldThemesController.onValueChanged += value;
        remove => _worldThemesController.onValueChanged -= value;
    }

    public GameSettingsController(GameData gameData) =>
        _gameData = gameData;

    internal void LoadModels(Scene scene, LoadSceneMode sceneMode)
    {
        PlayerThemeModel[] playerThemesModel = Array.ConvertAll(_gameData.PlayerThemeModels, i => new PlayerThemeModel(i.Icon));
        _playerThemesController.SetValues(playerThemesModel);

        int playerThemeIndex = Math.Clamp(_saveData.playerThemeIndex, 0, playerThemesModel.Length);
        _playerThemesController.SetValue(playerThemesModel[playerThemeIndex]);

        WorldThemeModel[] worldThemesModel = Array.ConvertAll(_gameData.WorldThemeModels, i => new WorldThemeModel(i.Icon));
        _worldThemesController.SetValues(worldThemesModel);

        int worldThemeIndex = Math.Clamp(_saveData.worldThemeIndex, 0, worldThemesModel.Length);
        _worldThemesController.SetValue(worldThemesModel[worldThemeIndex]);
    }
    internal void UnloadModels(Scene scene)
    {
        PlayerThemeData playerThemeModel = Array.Find(_gameData.PlayerThemeModels, x => x.Icon == _playerThemesController.GetValue().Icon);
        _saveData.playerThemeIndex = Array.IndexOf(_gameData.PlayerThemeModels, playerThemeModel);

        WorldThemeData worldThemeModel = Array.Find(_gameData.WorldThemeModels, x => x.Icon == _worldThemesController.GetValue().Icon);
        _saveData.worldThemeIndex = Array.IndexOf(_gameData.WorldThemeModels, worldThemeModel);
    }
}