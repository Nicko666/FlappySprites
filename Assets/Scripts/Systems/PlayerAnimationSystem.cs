using Leopotam.Ecs;

public class PlayerAnimationSystem : IEcsInitSystem, IEcsRunSystem
{
    private SceneEvents sceneEvents;

    private EcsFilter<Player> playerFilter;

    public void Init()
    {
        sceneEvents.onJump.AddListener(Jump);
    }

    public void Run()
    {
        foreach (var i in playerFilter)
        {
            ref var player = ref playerFilter.Get1(i);

            player.animator.SetFloat("moveY", player.rigidbody.velocityY);
        }
    }

    void Jump()
    {
        foreach (var i in playerFilter)
        {
            ref var player = ref playerFilter.Get1(i);

            player.animator.SetTrigger("jump");
        }
    }

    
}