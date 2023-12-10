using Leopotam.Ecs;
using UnityEngine;

public class PlayerInitSystem : IEcsInitSystem
{
    private EcsWorld ecsWorld;
    private SceneData sceneData;
    
    public void Init()
    {
        EcsEntity playerEntity = ecsWorld.NewEntity();

        ref var player = ref playerEntity.Get<Player>();

        //GameObject playerGO = Object.Instantiate(sceneData.player, sceneData.playerSpawnPoint.position, Quaternion.identity);
        GameObject playerGO = sceneData.player;

        player.transform = playerGO.GetComponent<Transform>();
        player.rigidbody = playerGO.GetComponent<Rigidbody2D>();
        player.animator = playerGO.GetComponent<Animator>();
        player.entity = playerEntity;
        player.playerThemes = playerGO.GetComponent<PlayerThemesAddressables>();
        player.playerCollision = playerGO.GetComponent<PlayerCollision>();
    }

}