using Unity.Entities;
using Unity.Jobs;
using Unity.Physics;

public class FreezeRotationSystem : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref FreezeRotation tag, ref PhysicsMass mass) => {

            mass.InverseInertia.x = tag.x ? 0 : mass.InverseInertia.x;
            mass.InverseInertia.y = tag.y ? 0 : mass.InverseInertia.y;
            mass.InverseInertia.z = tag.z ? 0 : mass.InverseInertia.z;

        }).ScheduleParallel();
    }
}
