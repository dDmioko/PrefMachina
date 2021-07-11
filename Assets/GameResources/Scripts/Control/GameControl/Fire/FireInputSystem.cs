using Leopotam.Ecs;

/// <summary>
/// Fire input system
/// </summary>
public class FireInputSystem : IEcsSystem
{
    private EcsFilter<FireInput> _filter = null;

    private FireInputControl input;

    public FireInputSystem(FireInputControl input)
    {
        this.input = input;

        input.Input += OnInput;
    }

    ~FireInputSystem()
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
