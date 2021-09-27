using UnityEngine;

/// <summary>
/// Rotate towards target, but only around y axis
/// </summary>
public class RotateTowardsTarget : Targetable
{
    [SerializeField]
    [Range(0, Mathf.PI)]
    private float speed = Mathf.PI;

    private void FixedUpdate()
    {
        if (target == false)
        {
            return;
        }

        RotateTowards();
    }

    private void RotateTowards()
    {
        Vector3 directionToTarget = target.position - transform.position;
        //Note: Rotate only around y axis
        directionToTarget.y = 0;

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, directionToTarget, speed, 0);

        transform.rotation = Quaternion.LookRotation(newDirection);
    }    
}