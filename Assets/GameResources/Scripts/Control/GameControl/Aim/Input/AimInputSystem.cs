using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Leopotam.Ecs;

public class AimInputSystem : IEcsSystem
{
    private EcsFilter<Aim, AimInput> _filter = null;

    private AimInputControl input;

    public AimInputSystem(AimInputControl input)
    {
        this.input = input;

        input.Input += OnInput;
    }

    ~AimInputSystem()
    {
        input.Input -= OnInput;
    }

    private void OnInput(Vector2 direction)
    {
        foreach (var i in _filter)
        {
            ref EcsEntity entity = ref _filter.GetEntity(i);
            ref Aim aim = ref _filter.Get1(i);

            aim.direction.x = direction.x;
            aim.direction.z = direction.y;
        }
    }
}
