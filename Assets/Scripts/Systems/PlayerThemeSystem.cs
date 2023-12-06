using Leopotam.Ecs;
using UnityEngine;

public class PlayerThemeSystem : IEcsInitSystem
{
    private SceneData sceneData;
    private SceneEvents sceneEvents;
    private StaticData staticData;
    private SettingsData settingsData;

    private EcsFilter<Player> playerFilter;

    public void Init()
    {
        sceneEvents.onPlayerThemeInput.AddListener(EnableButtons);
        sceneEvents.onPlayerThemeInput.AddListener(ChangePlayerTheme);
        sceneEvents.onPlayerThemeInput.AddListener(Save);

        sceneEvents.PlayerThemeInputNotify(
            settingsData.playerThemeID < staticData.playerThemes.Length ? settingsData.playerThemeID : 0);
    }

    void Save(int index)
    {
        settingsData.playerThemeID = index;
    }

    void EnableButtons(int index)
    {
        for(int i = 0; i < sceneData.playerThemesButtons.Length; i++)
        {
            sceneData.playerThemesButtons[i].Enable = (i != index);
        }
    }

    void ChangePlayerTheme(int index)
    {
        foreach (var i in playerFilter)
        {
            ref var player = ref playerFilter.Get1(i);
            //player.playerThemes.SetPlayerTheme(player, index);
            player.animator.runtimeAnimatorController = staticData.playerThemes[index].AnimatorController;

        }
    }

}