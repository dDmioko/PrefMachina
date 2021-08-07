using UnityEngine;

/// <summary>
/// Follow object not changing position against it
/// </summary>
public class FollowGameObject : MonoBehaviour
{
    [SerializeField] private GameObject target;

    private Vector3 previousTargetPosition;

    private void Awake()
    {
        previousTargetPosition = target.transform.position;
    }

    private void LateUpdate()
    {
        if (previousTargetPosition != target.transform.position)
        {
            transform.position += target.transform.position - previousTargetPosition;
            previousTargetPosition = target.transform.position;
        }
    }
}
