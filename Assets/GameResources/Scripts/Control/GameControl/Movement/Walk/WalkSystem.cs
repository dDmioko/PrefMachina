using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Leopotam.Ecs;

/// <summary>
/// Add velocity to body
/// </summary>
public class WalkSystem : IEcsRunSystem
{
    private EcsFilter<Walk> _filter = null;

    public void Run()
    {        
        foreach (var i in _filter)
        {
            ref EcsEntity entity = ref _filter.GetEntity(i);
            ref Walk walk = ref _filter.Get1(i);

            walk.body.velocity = walk.velocity;
        }
    }
}
