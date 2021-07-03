using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Leopotam.Ecs;

/// <summary>
/// Get input and add it to walk component
/// </summary>
public class WalkInputSystem : IEcsSystem
{
    private EcsFilter<Walk, WalkInput> _filter = null;

    private WalkInputControl input;

    public WalkInputSystem(WalkInputControl input)
    {
        this.input = input;

        input.Input += OnInput;
    }

    ~WalkInputSystem()
    {
        input.Input -= OnInput;
    }

    private void OnInput(Vector2 direction)
    {
        foreach (var i in _filter)
        {
            ref EcsEntity entity = ref _filter.GetEntity(i);
            ref Walk movable = ref _filter.Get1(i);

            float x = movable.speed * direction.x;
            float z = movable.speed * direction.y;

            movable.velocity = z * movable.transform.forward + x * movable.transform.right;
        }
    }
}
