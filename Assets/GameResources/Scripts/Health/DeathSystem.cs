using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

public class DeathSystem : EcsSystemWrapper, IEcsRunSystem
{
    private EcsFilter<Health> _filter = null;

    public void Run()
    {
        foreach (var i in _filter)
        {
            ref Health health = ref _filter.Get1(i);

            if (health.amount <= 0)
            {
                health.gameObject.SetActive(false);
            }
        }
    }
}
