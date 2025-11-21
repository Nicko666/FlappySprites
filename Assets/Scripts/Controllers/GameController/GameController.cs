using System;
using UnityEngine;

public class GameController : Controller
{
    private MyDatabaseController<GameDatabase> _gameDatabaseController;
    private MyFileController<GameSettingsModel> _gameSettingsController;
    private GameSettingsModel _gameSettingsModel;
    private MyFileController<GameProgressModel> _gameProgressController;
    private GameProgressModel _gameProgressModel;

    private ValueController<PlayerThemeModel> _playerThemeController;
    private ValueController<WorldThemeModel> _worldThemeController;
    private GameRecordController _gamePointsController;

    private GamePresenter _gamePresenter;

    public GameController(
        ProjectPresenter loadingPresenter,
        GameDatabase gameDatabase,
        GamePresenter gamePresenter
        ) : base(loadingPresenter)
    {
        _gameDatabaseController = new(gameDatabase);
        _gameSettingsController = new(Application.persistentDataPath, "settingsData");
        _gameProgressController = new(Application.persistentDataPath, "localData ", "test");
        _playerThemeController = new ();
        _worldThemeController = new ();
        _gamePointsController = new();
        _gamePresenter = gamePresenter;

        _gameDatabaseController.onLoadDatabase += SetGameSettingsDatabase;
        _playerThemeController.onValueChanged += OutputPlayerThemeModel;
        _worldThemeController.onValueChanged += OutputWorldThemeModel;
        _gamePresenter.onInputPlayerThemeModel += SetPlayerThemeModel;
        _gamePresenter.onInputWorldThemeModel += SetWorldThemeModel;
        _gamePresenter.onInputRecords += OutputRecords;
        _gamePresenter.onInputAddPointsModel += AddCurrentPointsModel;
        _gamePresenter.onClearCurrentPointsModel += ClearCurrentPointsModel;
        _gamePointsController.onRecordPointsModelChanged += OutputRecordPointsModel;
        _gamePointsController.onCurrentPointsModelChanged += OutputCurrentPointsModel;
        _gamePointsController.onNewRecord += OutputNewRecord;
    }
    public override void Dispose()
    {
        _gameDatabaseController.onLoadDatabase -= SetGameSettingsDatabase;
        _playerThemeController.onValueChanged -= OutputPlayerThemeModel;
        _worldThemeController.onValueChanged -= OutputWorldThemeModel;
        _gamePresenter.onInputPlayerThemeModel -= SetPlayerThemeModel;
        _gamePresenter.onInputWorldThemeModel -= SetWorldThemeModel;
        _gamePresenter.onInputRecords -= OutputRecords;
        _gamePresenter.onInputAddPointsModel -= AddCurrentPointsModel;
        _gamePresenter.onClearCurrentPointsModel -= ClearCurrentPointsModel;
        _gamePointsController.onRecordPointsModelChanged -= OutputRecordPointsModel;
        _gamePointsController.onCurrentPointsModelChanged -= OutputCurrentPointsModel;
        _gamePointsController.onNewRecord -= OutputNewRecord;
    }

    private void SetGameSettingsDatabase(GameDatabase gameModel)
    {
        _gamePresenter.OutputDatabase(gameModel);
        _playerThemeController.SetValues(gameModel.PlayerThemeModels);
        _worldThemeController.SetValues(gameModel.WorldThemeModels);
    }

    private void OutputRecordPointsModel(int points)
    {
        _gamePresenter.OutputRecordPointsModel(points);
        _googlePlayController.SetLiderboardGlobalPoints(points);
    }

    private void OutputRecords() =>
        _googlePlayController.OutputRecords();

    private void OutputNewRecord() =>
            _gamePresenter.OutputNewRecord();

    private void OutputCurrentPointsModel(int value) =>
        _gamePresenter.OutputCurrentPointsModel(value);

    private void OutputPlayerThemeModel(PlayerThemeModel playerThemeModel) =>
        _gamePresenter.OutputSettingsPresenter(playerThemeModel);

    private void OutputWorldThemeModel(WorldThemeModel model) =>
        _gamePresenter.OutputWorldThemeModel(model);

    private void AddCurrentPointsModel() =>
        _gamePointsController.AddCurrentPointsModel();
    
    private void ClearCurrentPointsModel() =>
        _gamePointsController.ClearCurrentPointsModel();

    private void SetWorldThemeModel(WorldThemeModel worldThemeModel) =>
        _worldThemeController.SetValue(worldThemeModel);

    private void SetPlayerThemeModel(PlayerThemeModel playerThemeModel) =>
        _playerThemeController.SetValue(playerThemeModel);

    protected override void LoadData()
    {
        _gameDatabaseController.LoadDatabase();

        _gameSettingsModel = _gameSettingsController.Load();
        _gameSettingsModel ??= new();

        _playerThemeController.SetValue(Array.Find(_playerThemeController.GetValues(), x => x.ID == _gameSettingsModel.playerThemeIndex));
        _worldThemeController.SetValue(Array.Find(_worldThemeController.GetValues(), x => x.ID == _gameSettingsModel.worldThemeIndex));

        _gameProgressModel = _gameProgressController.Load();
        _gameProgressModel ??= new();

        _gamePointsController.SetRecordPointsModel(_gameProgressModel.personalRecord);

        base.LoadData();
    }
    protected override void SaveData()
    {
        _gameSettingsModel.playerThemeIndex = _playerThemeController.GetValue().ID;
        _gameSettingsModel.worldThemeIndex = _worldThemeController.GetValue().ID;

        _gameSettingsController.Save(_gameSettingsModel);

        _gameProgressModel.personalRecord = _gamePointsController.GetRecordPointsModel();
        
        _gameProgressController.Save(_gameProgressModel);

        base.SaveData();
    }
}