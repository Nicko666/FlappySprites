using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GamePresenter : MonoBehaviour
{
    [SerializeField] private StagePresenter _stagePresenter = new();
    [SerializeField] private PlayerPresenter _playerPresenter;
    [SerializeField] private WorldPresenter _worldPresenter;
    [SerializeField] private MenuUIPresenter _menuUIPresenter;
    [SerializeField] private PlayUIPresenter _playUIPresenter;
    [SerializeField] private RecordsUIPresenter _recordsUIPresenter;
    [SerializeField] private float 
        _arithmeticAccelerator = 0.001f, 
        _geometricAccelerator = 1f, 
        _maxTimeScale = 10;

    private Coroutine _speedCoroutine;

    internal event Action onClearCurrentPointsModel
    {
        add => _playerPresenter.onInputClearPointsModel += value;
        remove => _playerPresenter.onInputClearPointsModel -= value;
    }
    internal event Action onInputAddPointsModel
    {
        add => _playerPresenter.onInputAddPointsModel += value;
        remove => _playerPresenter.onInputAddPointsModel -= value;
    }
    internal event Action<PlayerThemeModel> onInputPlayerThemeModel
    {
        add => _menuUIPresenter.onInputPlayerThemeModel += value;
        remove => _menuUIPresenter.onInputPlayerThemeModel -= value;
    }
    internal event Action<WorldThemeModel> onInputWorldThemeModel
    {
        add => _menuUIPresenter.onInputWorldThemeModel += value;
        remove => _menuUIPresenter.onInputWorldThemeModel -= value;
    }
    internal event UnityAction onInputRecords
    {
        add => _menuUIPresenter.onInputRecords += value;
        remove => _menuUIPresenter.onInputRecords -= value;
    }

    internal void OutputDatabase(GameDatabase gameModel) =>
        _menuUIPresenter.OutputSettingsDatabase(gameModel);

    internal void OutputWorldThemeModel(WorldThemeModel worldThemeModel)
    {
        _worldPresenter.OutputWorldThemeModel(worldThemeModel);
        _menuUIPresenter.OutputWorldThemeModel(worldThemeModel);
    }

    internal void OutputSettingsPresenter(PlayerThemeModel playerThemeModel)
    {
        _playerPresenter.OutputPlayerThemeModel(playerThemeModel);
        _menuUIPresenter.OutputPlayerThemeModel(playerThemeModel);
    }

    internal void OutputRecordPointsModel(int value) =>
        _menuUIPresenter.OutputNewRecordModel(value);

    internal void OutputNewRecord() =>
        _recordsUIPresenter.OutputNewRecordModel();

    internal void OutputCurrentPointsModel(int value)
    {
        _playUIPresenter.OutputCurrentPointsModel(value);
        _recordsUIPresenter.OutputCurrentPointsModel(value);
    }

    private void Awake()
    {
        _menuUIPresenter.onInputPlay += OutputPlay;
        _recordsUIPresenter.onInputMenu += OutputMenu;
        _playerPresenter.onInputDie += OutputRecords;
        _stagePresenter.onInputMenu += OutputMenu;
        _stagePresenter.onInputPlay += OutputPlay;
        _stagePresenter.onInputRecord += OutputRecords;
        _playUIPresenter.onInputJump += OutputJump;
    }
    private void OnDestroy()
    {
        _menuUIPresenter.onInputPlay -= OutputPlay;
        _recordsUIPresenter.onInputMenu -= OutputMenu;
        _playerPresenter.onInputDie -= OutputRecords;
        _stagePresenter.onInputMenu -= OutputMenu;
        _stagePresenter.onInputPlay -= OutputPlay;
        _stagePresenter.onInputRecord -= OutputRecords;
        _playUIPresenter.onInputJump -= OutputJump;
    }
    private void Start() =>
        _stagePresenter.OutputStageModel(StageModel.Menu);

    private void OutputJump() =>
        _playerPresenter.OutputJump();

    private void OutputMenu()
    {
        _menuUIPresenter.OutputPanel(true);
        _playUIPresenter.OutputPanel(false);
        _recordsUIPresenter.OutputPanel(false);
        _playerPresenter.OutputIdol();
        _worldPresenter.OutputIdol();

        if (_speedCoroutine != null) StopCoroutine(_speedCoroutine);
        Time.timeScale = 1;
    }
    private void OutputPlay()
    {
        _menuUIPresenter.OutputPanel(false);
        _playUIPresenter.OutputPanel(true);
        _recordsUIPresenter.OutputPanel(false);
        _playerPresenter.OutputPlay();
        _worldPresenter.OutputPlay();
        
        if (_speedCoroutine != null) StopCoroutine(_speedCoroutine);

        _speedCoroutine = StartCoroutine(SpeedCoroutine());
        IEnumerator SpeedCoroutine()
        {
            Time.timeScale = 1;
            while (Time.timeScale < _maxTimeScale)
            {
                yield return new WaitForFixedUpdate();
                Time.timeScale *= _geometricAccelerator;
                Time.timeScale += _arithmeticAccelerator;

                _playUIPresenter.OutputSpeed(Time.timeScale);
            }
        }
    }
    private void OutputRecords()
    {
        if (_speedCoroutine != null) StopCoroutine(_speedCoroutine);
        Time.timeScale = 0;

        _menuUIPresenter.OutputPanel(false);
        _playUIPresenter.OutputPanel(false);
        _recordsUIPresenter.OutputPanel(true);
        _playerPresenter.OutputPause();
        _worldPresenter.OutputPause();
    }

    private void OutputPointsModel(int points)
    {
        _playUIPresenter.OutputCurrentPointsModel(points);
        _recordsUIPresenter.OutputCurrentPointsModel(points);
    }

    private void OutputSpeed(float speedModel)
    {
        
    }
}
