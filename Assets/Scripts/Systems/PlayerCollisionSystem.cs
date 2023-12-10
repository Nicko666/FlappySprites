using Leopotam.Ecs;

public class PlayerCollisionSystem : IEcsInitSystem
{
    private EcsFilter<Player> playerFilter;
    private SceneEvents sceneEvents;

    public void Init()
    {
        foreach (var i in playerFilter)
        {
            ref var player = ref playerFilter.Get1(i);

            player.playerCollision.onObstacle.AddListener(PlayerObstacle);
            player.playerCollision.onCheckpoint.AddListener(PlayerHitPoint);
        }
    }

    void PlayerObstacle()
    {
        sceneEvents.EndGameNotify();
    }

    void PlayerHitPoint()
    {
        sceneEvents.AddPointNotify();
    }

}