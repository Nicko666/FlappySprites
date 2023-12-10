using Leopotam.Ecs;
using UnityEngine;

public class PlayerGravityMultiplyerSystem : IEcsRunSystem
{
    StaticData staticData;
    EcsFilter<Player> playerFilter;

    public void Run()
    {
        foreach (var i in playerFilter)
        {
            ref var player = ref playerFilter.Get1(i);

            if (player.rigidbody.velocity.y < 0)
                player.rigidbody.velocity *= Vector2.down * staticData.playerGravityMultiplyer;
        }
    }
}
