using System;

internal class GameRecordController
{
    private int _recordPointsModel;
    private int _currentPointsModel;

    internal Action<int> onCurrentPointsModelChanged;
    internal Action<int> onRecordPointsModelChanged;
    internal Action onNewRecord;

    internal void ClearCurrentPointsModel()
    {
        _currentPointsModel = 0;

        onCurrentPointsModelChanged.Invoke(_currentPointsModel);
    }

    internal void AddCurrentPointsModel()
    {
        _currentPointsModel++;

        onCurrentPointsModelChanged.Invoke(_currentPointsModel);

        if (_currentPointsModel > _recordPointsModel)
        {
            _recordPointsModel = _currentPointsModel;
            onRecordPointsModelChanged.Invoke(_recordPointsModel);
            onNewRecord.Invoke();
        }
    }

    internal void SetRecordPointsModel(int points)
    {
        _recordPointsModel = points;

        onRecordPointsModelChanged.Invoke(_recordPointsModel);
    }

    internal int GetRecordPointsModel() =>
        _recordPointsModel;
}