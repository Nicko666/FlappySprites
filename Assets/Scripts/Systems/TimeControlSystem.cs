using Leopotam.Ecs;
using UnityEngine;

public class TimeControlSystem : IEcsInitSystem
{
    private SceneEvents sceneEvents;
    private SceneData sceneData;

    public void Init()
    {
        sceneEvents.onMenu.AddListener(MenuTimeScale);
        sceneEvents.onPlay.AddListener(GameTimeScale);
        sceneEvents.onEndGame.AddListener(EndGameTimeScale);
    }

    void MenuTimeScale()
    {
        sceneData.timeAccelerationSystem.enabled = false;
        Time.timeScale = 1f;
    }

    void GameTimeScale()
    {
        Time.timeScale = 1f;
        sceneData.timeAccelerationSystem.enabled = true;
    }

    void EndGameTimeScale()
    {
        sceneData.timeAccelerationSystem.enabled = false;
        Time.timeScale = 0f;
    }

}