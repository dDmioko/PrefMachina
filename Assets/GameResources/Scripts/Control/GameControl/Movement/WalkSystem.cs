using Unity.Entities;
using Unity.Physics;

/// <summary>
/// Add velocity to body
/// </summary>
[UpdateInGroup(typeof(FixedStepSimulationSystemGroup))]
public class WalkSystem : SystemBase
{
    //private EcsFilter<Walk> _filter = null;

    public void Run()
    {
        //foreach (var i in _filter)
        //{
        //    ref Walk walk = ref _filter.Get1(i);

        //    walk.body.velocity = walk.velocity;
        //}
    }

    protected override void OnUpdate()
    {
        Entities.ForEach((ref PhysicsVelocity velocity, in Walk walk) => {

            velocity.Linear = walk.velocity;

        }).Run();
    }
}
