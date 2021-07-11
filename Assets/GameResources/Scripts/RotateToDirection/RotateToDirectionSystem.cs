using UnityEngine;

using Leopotam.Ecs;

/// <summary>
/// Rotate moving object towards its direction
/// </summary>
public class RotateToDirectionSystem : EcsSystemWrapper, IEcsRunSystem
{
    private EcsFilter<RotateToDirection> _filter = null;

    public void Run()
    {
        foreach (var i in _filter)
        {
            ref RotateToDirection rotateToDirecion = ref _filter.Get1(i);

            if (rotateToDirecion.gameObject.activeSelf)
            {
                Vector3 direction = rotateToDirecion.transform.position - rotateToDirecion.previousPosition;

                if (direction != Vector3.zero)
                {
                    rotateToDirecion.transform.rotation = Quaternion.LookRotation(direction);
                }

                rotateToDirecion.previousPosition = rotateToDirecion.transform.position;
            }
        }
    }
}
