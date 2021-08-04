using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

/// <summary>
/// Rotate
/// </summary>
[UpdateInGroup(typeof(FixedStepSimulationSystemGroup))]
public class AimSystem : SystemBase
{
    protected override void OnCreate()
    {
        base.OnCreate();

        //Entities.ForEach((ref Aim aim) =>
        //{
        //    aim.rotation = EntityManager.GetComponentObject<Rotation>(aim.entity);
        //}).WithoutBurst().Run();
    }

    protected override void OnUpdate()
    {
        Entities.ForEach((ref Aim aim) => {
            
            Vector3 newDirection = Vector3.RotateTowards(Vector3.forward, aim.direction, aim.speed, 0.0f);
            Rotation rotation = EntityManager.GetComponentObject<Rotation>(aim.bodyEntity);
            rotation.Value = Quaternion.LookRotation(newDirection);

        }).WithoutBurst().Run();
    }
}
