using Leopotam.Ecs;
using System.Text;

public class CurrentPointsSystem : IEcsInitSystem
{
    private SceneData sceneData;
    private SceneEvents sceneEvents;
    private RuntimeData runtimeData;

    StringBuilder builder;

    public void Init()
    {
        sceneEvents.onPlay.AddListener(ZeroPoints);
        sceneEvents.onAddPoint.AddListener(AddPoint);

        builder = new StringBuilder(10);
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
        builder.Length = 0;
        builder.Append(runtimeData.currentPoints);

        foreach (var points in sceneData.currentPointsTexts)
            points.text = builder.ToString();
    }


}