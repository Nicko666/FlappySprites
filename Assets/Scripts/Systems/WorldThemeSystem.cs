using Leopotam.Ecs;

public class WorldThemeSystem : IEcsInitSystem
{
    private SceneData sceneData;
    private SceneEvents sceneEvents;
    private StaticData staticData;
    private SettingsData settingsData;

    public void Init()
    {
        sceneEvents.onWorldThemeInput.AddListener(EnableButtons);
        sceneEvents.onWorldThemeInput.AddListener(ChangeWorldTheme);
        sceneEvents.onWorldThemeInput.AddListener(Save);

        sceneEvents.WorldThemeInputNotify(
            settingsData.worldThemeID < staticData.worldThemes.Length ? settingsData.worldThemeID : 0);
    }

    void Save(int index)
    {
        settingsData.worldThemeID = index;
    }

    void EnableButtons(int index)
    {
        for (int i = 0; i < sceneData.worldThemesButtons.Length; i++)
        {
            sceneData.worldThemesButtons[i].Enable = (i != index);
        }
    }

    void ChangeWorldTheme(int index)
    {
        sceneData.sky.sprite = staticData.worldThemes[index].SkySprite;
        
        foreach (var spriteRenderer in sceneData.farBackground)
        {
            spriteRenderer.sprite = staticData.worldThemes[index].FarBackground;
        }
        foreach (var spriteRenderer in sceneData.closeBackground)
        {
            spriteRenderer.sprite = staticData.worldThemes[index].CloseBackground;
        }
        foreach (var spriteRenderer in sceneData.obstaclesSpawn.spriteRenderers)
        {
            spriteRenderer.sprite = staticData.worldThemes[index].Obstacles;
        }
        foreach (var spriteRenderer in sceneData.platforms)
        {
            spriteRenderer.sprite = staticData.worldThemes[index].Platform;
        }
    }
}