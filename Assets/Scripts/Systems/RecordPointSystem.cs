using Leopotam.Ecs;
using UnityEngine;

public class RecordPointSystem : IEcsInitSystem
{
    private SceneData sceneData;
    private SceneEvents sceneEvents;
    private RuntimeData runtimeData;
    private LocalData localData;
    private GooglePlayData googlePlayData;

    string message;
    int oldRecord;

    public void Init()
    {
        sceneEvents.onPlay.AddListener(OnStart);
        sceneEvents.onEndGame.AddListener(OnEnd);

        OnStart();
    }


    void OnStart()
    {
        oldRecord = localData.personalRecord;
        message = " ";

        ShowRecords();
    }

    void OnEnd()
    {
        if (runtimeData.currentPoints > localData.personalRecord)
        {
            SavePersonalRecord(runtimeData.currentPoints);
            message = "New personal record!";
        }
        
        SaveGlobalRecord(runtimeData.currentPoints);

        ShowRecords();
    }

    void ShowRecords()
    {
        foreach (var text in sceneData.personalRecordText)
            text.text = localData.personalRecord.ToString();

        foreach (var text in sceneData.oldPersonalRecordText)
            text.text = oldRecord.ToString();

        foreach (var text in sceneData.endGameMessage)
            text.text = message;

    }

    void SavePersonalRecord(int value)
    {
        localData.personalRecord = value;
    }

    void SaveGlobalRecord(int value)
    {
        googlePlayData.LiderboardGlobalPoints(value);
        Debug.Log("Global Record Saving ended");
    }

}