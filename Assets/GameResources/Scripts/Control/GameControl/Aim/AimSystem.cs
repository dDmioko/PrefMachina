using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

/// <summary>
/// Rotate
/// </summary>
[UpdateInGroup(typeof(FixedStepSimulationSystemGroup))]
public class AimSystem : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref Rotation rotation, in Aim aim) => {
            
            Vector3 newDirection = Vector3.RotateTowards(Vector3.forward, aim.direction, aim.speed, 0.0f);
            rotation.Value = Quaternion.LookRotation(newDirection);

        }).ScheduleParallel();
    }
}
