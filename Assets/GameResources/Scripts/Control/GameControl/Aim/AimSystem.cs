using UnityEngine;

/// <summary>
/// Rotate
/// </summary>
public class AimSystem : EcsSystemWrapper
{
    //private EcsFilter<Aim> _filter = null;

    public void Run()
    {
        //foreach (var i in _filter)
        //{
        //    ref Aim aim = ref _filter.Get1(i);

        //    Vector3 newDirection = Vector3.RotateTowards(aim.transform.forward, aim.direction, aim.speed, 0.0f);
        //    aim.transform.rotation = Quaternion.LookRotation(newDirection);
        //}
    }
}
