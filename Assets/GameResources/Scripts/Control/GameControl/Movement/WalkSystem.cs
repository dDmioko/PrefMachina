using Unity.Entities;
using Unity.Physics;

/// <summary>
/// Add velocity to body
/// </summary>
[UpdateInGroup(typeof(FixedStepSimulationSystemGroup))]
public class WalkSystem : SystemBase
{ 
    protected override void OnUpdate()
    {        
        Entities.ForEach((ref PhysicsVelocity velocity, in Walk walk) => {

            velocity.Linear = walk.direction * walk.speed;

        }).ScheduleParallel();
    }
}
