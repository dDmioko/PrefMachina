using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Trigger event than target close enough, then deactivate this script
/// </summary>
public class ArriveTarget : TargetDependent
{
    public UnityEvent TargetAchieved;

    [SerializeField]
    private float triggerDistance = 2.5f;

    private void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, target.position) < triggerDistance)
        {
            TargetAchieved?.Invoke();

            enabled = false;
        }
    }
}
