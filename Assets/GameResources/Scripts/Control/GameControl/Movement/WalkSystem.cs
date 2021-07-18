using Leopotam.Ecs;

/// <summary>
/// Add velocity to body
/// </summary>
public class WalkSystem : EcsSystemWrapper, IEcsRunSystem
{
    private EcsFilter<Walk> _filter = null;

    public void Run()
    {
        foreach (var i in _filter)
        {
            ref Walk walk = ref _filter.Get1(i);

            walk.body.velocity = walk.velocity;
        }
    }
}
