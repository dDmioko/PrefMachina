using UnityEngine;

/// <summary>
/// Get input and add it to aim component
/// </summary>
public class AimInputSystem
{
    //private EcsFilter<Aim, AimInput> _filter = null;

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
        //foreach (var i in _filter)
        //{
        //    ref Aim aim = ref _filter.Get1(i);

        //    aim.direction.x = direction.x;
        //    aim.direction.z = direction.y;
        //}
    }
}
