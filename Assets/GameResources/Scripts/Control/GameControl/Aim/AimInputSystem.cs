using UnityEngine;

using Leopotam.Ecs;

public class AimInputSystem : EcsSystemWrapper
{
    private EcsFilter<Aim, AimInput> _filter = null;

    [SerializeField] private AimInputControl input;

    private void OnEnable()
    {
        input.Input += OnInput;
    }

    private void OnDisable()
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
