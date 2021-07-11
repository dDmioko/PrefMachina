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
        input.Input += OnInput;
    }

    private void OnDisable()
    {
        input.Input -= OnInput;
    }

    private void OnInput()
    {
        foreach (var i in _filter)
        {
            ref EcsEntity entity = ref _filter.GetEntity(i);
            ref FireInput input = ref _filter.Get1(i);

            input.Event?.Invoke();
        }
    }
}
