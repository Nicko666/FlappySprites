using Leopotam.Ecs;

public class ObstacleInitSystem : IEcsInitSystem
{
    private SceneData sceneData;
    private SceneEvents sceneEvents;

    public void Init()
    {
        sceneEvents.onPlay.AddListener(Enable);
        sceneEvents.onMenu.AddListener(Disable);
    }

    void Enable() => sceneData.obstaclesSpawn.enabled = true;
    void Disable() => sceneData.obstaclesSpawn.enabled = false;

}