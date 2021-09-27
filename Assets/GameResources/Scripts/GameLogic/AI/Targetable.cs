using UnityEngine;

/// <summary>
/// Component that has target
/// </summary>
public class Targetable : MonoBehaviour
{
    [SerializeField]
    protected Transform target = default;

    /// <summary>
    /// Set target to follow
    /// </summary>
    /// <param name="target"></param>
    public void SetTarget(Transform target)
    {
        this.target = target;
    }
}
