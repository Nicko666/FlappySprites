using Leopotam.Ecs;

public class CurrentPointsSystem : IEcsInitSystem
{
    private SceneData sceneData;
    private SceneEvents sceneEvents;
    private RuntimeData runtimeData;

    public void Init()
    {
        sceneEvents.onPlay.AddListener(ZeroPoints);
        sceneEvents.onAddPoint.AddListener(AddPoint);
    }

    void ZeroPoints()
    {
        runtimeData.currentPoints = 0;

        DisplayPoints();
    }

    void AddPoint()
    {
        runtimeData.currentPoints++;

        DisplayPoints();
    }

    void DisplayPoints()
    {
        foreach (var points in sceneData.currentPointsTexts)
            points.text = runtimeData.currentPoints.ToString();
    }


}