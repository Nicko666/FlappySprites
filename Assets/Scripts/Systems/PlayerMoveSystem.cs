using Leopotam.Ecs;
using UnityEngine;

public class PlayerMoveSystem : IEcsInitSystem
{
    SceneData sceneData;
    SceneEvents sceneEvents;
    StaticData staticData;

    EcsFilter<Player> playerFilter;

    public void Init()
    {
        sceneEvents.onPlay.AddListener(Enable);
        sceneEvents.onMenu.AddListener(Disable);
        sceneEvents.onJump.AddListener(Jump);
    }

    void Enable()
    {
        foreach (var i in playerFilter)
        {
            ref var player = ref playerFilter.Get1(i);

            player.rigidbody.gravityScale = 1;
        }
    }
    void Disable()
    {
        foreach (var i in playerFilter)
        {
            ref var player = ref playerFilter.Get1(i);

            player.rigidbody.gravityScale = 0;
            player.rigidbody.velocity = Vector3.zero;
            player.transform.position = sceneData.playerSpawnPoint.position;
        }
    }

    void Jump()
    {
        foreach (var i in playerFilter)
        {
            ref var player = ref playerFilter.Get1(i);

            player.rigidbody.velocity = Vector2.up * staticData.jumpForce;
        }
    }
    
}
