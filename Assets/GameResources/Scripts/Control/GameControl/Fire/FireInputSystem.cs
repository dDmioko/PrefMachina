using Leopotam.Ecs;
using UnityEngine;

/// <summary>
/// Fire input system
/// </summary>
public class FireInputSystem : EcsSystemWrapper, IEcsSystem
{
    private EcsFilter<FireInput> _filter = null;

    [SerializeField] private FireInputControl input;

    private void OnEnable()
    {
        input.Down += OnDown;
        input.Up += OnUp;
    }

    private void OnDisable()
    {
        input.Down -= OnDown;
        input.Up -= OnUp;
    }

    private void OnUp()
    {
        foreach (var i in _filter)
        {
            ref FireInput input = ref _filter.Get1(i);

            input.Up?.Invoke();
        }
    }

    private void OnDown()
    {
        foreach (var i in _filter)
        {
            ref FireInput input = ref _filter.Get1(i);

            input.Down?.Invoke();
        }
    }
}
