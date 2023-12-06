using Leopotam.Ecs;
using UnityEngine;

public class PlayerLifeSystem : IEcsInitSystem, IEcsRunSystem
{
    private EcsFilter<Player> playerFilter;
    private EcsFilter<Player, PlayerData> playerDataFilter;
    private SceneData sceneData;
    private StaticData staticData;
    private RuntimeData runtimeData;
    private SceneEvents sceneEvents;

    RaycastHit2D hit;
    Transform lastPoint = null;

    public void Init()
    {
        sceneEvents.onPlay.AddListener(Enable);
        sceneEvents.onMenu.AddListener(Disable);

        sceneData.jumpButton.onClick.AddListener(Jump);
    }

    public void Run()
    {
        foreach (var i in playerDataFilter)
        {
            ref var player = ref playerDataFilter.Get1(i);
            ref var playerData = ref playerDataFilter.Get2(i);

            if (player.rigidbody.velocity.y < 0)
                player.rigidbody.velocity += Vector2.down * staticData.additionalGravity;

            hit = Physics2D.CircleCast(player.transform.position, staticData.raycastRadius, Vector2.zero, 0f);
            if (hit)
            {
                if (hit.transform.tag == "Obstacle")
                {
                    PlayerDie();
                    lastPoint = null;
                }
                else if (hit.transform.tag == "Point" & hit.transform != lastPoint)
                {
                    lastPoint = hit.transform;
                    PlayerHitPoint();
                }
            }
        }

        foreach (var i in playerFilter)
        {
            ref var player = ref playerFilter.Get1(i);

            player.animator.SetFloat("moveY", player.rigidbody.velocityY);
        }
    }

    void PlayerDie()
    {
        sceneEvents.EndGameNotify();
    }

    void PlayerHitPoint()
    {
        sceneEvents.AddPointNotify();
    }

    void Enable()
    {
        foreach (var i in playerFilter)
        {
            ref var player = ref playerFilter.Get1(i);

            player.rigidbody.gravityScale = staticData.gravityScale;
            player.entity.Get<PlayerData>();
        }
    }

    void Jump()
    {
        foreach (var i in playerDataFilter)
        {
            ref var player = ref playerDataFilter.Get1(i);

            player.rigidbody.velocity = Vector2.up * staticData.jumpForce;
            player.animator.SetTrigger("jump");
        }
    }

    void Disable()
    {
        foreach (var i in playerFilter)
        {
            ref var player = ref playerFilter.Get1(i);

            player.rigidbody.gravityScale = 0f;
            player.rigidbody.velocity = Vector2.zero;
            player.transform.position = sceneData.playerSpawnPoint.position;
            player.animator.ResetTrigger("jump");
        }

        foreach (var i in playerDataFilter)
        {
            ref var player = ref playerDataFilter.Get1(i);
            player.entity.Del<PlayerData>();
        }
    }



}