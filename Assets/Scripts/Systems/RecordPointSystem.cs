using Leopotam.Ecs;

public class RecordPointSystem : IEcsInitSystem
{
    private SceneData sceneData;
    private SceneEvents sceneEvents;
    private RuntimeData runtimeData;
    private LocalData localData;

    string message;
    int oldRecord;

    public void Init()
    {
        sceneEvents.onEndGame.AddListener(SetMaxPoints);

        message = "";
        oldRecord = localData.personalRecord;

        ShowRecords();
    }

    void SetMaxPoints()
    {
        oldRecord = localData.personalRecord;

        if (runtimeData.currentPoints > localData.personalRecord)
        {
            SavePersonalRecord(runtimeData.currentPoints);
            message = "New personal record!";
        }
        else
        {
            message = "";
        }

        ShowRecords();
    }

    void ShowRecords()
    {
        foreach (var text in sceneData.personalRecordText)
            text.text = localData.personalRecord.ToString();

        foreach (var text in sceneData.oldPersonalRecordText)
            text.text = oldRecord.ToString();

        //foreach (var text in sceneData.globalRecordText)
        //    text.text = runtimeData.globalRecordText.ToString();

        foreach (var text in sceneData.endGameMessage)
            text.text = message;
    }

    void SavePersonalRecord(int value)
    {
        localData.personalRecord = value;
    }

    void SaveGlobalRecord(int value)
    {

    }

}