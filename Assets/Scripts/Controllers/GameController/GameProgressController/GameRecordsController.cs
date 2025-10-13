using System;
using UnityEngine;

internal class GameRecordsController : MonoBehaviour
{
    private MyFileController<GameProgressDataModel> _settingsDataHandler;
    private GameProgressDataModel _progressModel;

    internal Action<int> onPersonalRecordChanged;

    private int _personalRecord;

    internal GameRecordsController()
    {
        _settingsDataHandler = new(Application.persistentDataPath, "localData ", "test");
    }

    internal void LoadModels()
    {
        _progressModel = _settingsDataHandler.Load();
        _progressModel ??= new();

        _personalRecord = _progressModel.personalRecord;

        onPersonalRecordChanged.Invoke(_personalRecord);
    }
    internal void SaveModels()
    {
        _progressModel.personalRecord = _personalRecord;

        _settingsDataHandler.Save(_progressModel);
    }

    internal void SetPersonalRecord(int value)
    {
        _personalRecord = value;

        onPersonalRecordChanged.Invoke(_personalRecord);
    }
}
