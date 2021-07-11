using Leopotam.Ecs;

/// <summary>
/// Subscribe guns fire functions to input event
/// </summary>
public class SubscribeGunsToInputEvent : IEcsInitSystem
{
    private EcsFilter<Fire, FireInput> _filter = null;

    public void Init()
    {
        foreach (var i in _filter)
        {
            ref EcsEntity entity = ref _filter.GetEntity(i);
            ref Fire fire = ref _filter.Get1(i);
            ref FireInput input = ref _filter.Get2(i);

            foreach (AbstractGun gun in fire.Guns)
            {
                input.Event += gun.Fire;
            }
        }
    }
}
