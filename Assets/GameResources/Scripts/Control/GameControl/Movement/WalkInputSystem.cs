using UnityEngine;

/// <summary>
/// Get input and add it to walk component
/// </summary>
public class WalkInputSystem : EcsSystemWrapper
{
    //private EcsFilter<Walk, WalkInput> _filter = null;

    [SerializeField] private WalkInputControl input;

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
        //    ref Walk movable = ref _filter.Get1(i);

        //    float x = movable.speed * direction.x;
        //    float z = movable.speed * direction.y;

        //    movable.velocity = z * movable.transform.forward + x * movable.transform.right;
        //}
    }
}
