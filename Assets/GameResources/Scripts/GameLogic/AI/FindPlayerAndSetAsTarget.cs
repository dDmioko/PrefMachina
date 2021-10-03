using UnityEngine;

/// <summary>
/// Set player as target to components
/// </summary>
public class FindPlayerAndSetAsTarget : MonoBehaviour
{
    [SerializeField]
    private TargetDependent[] targetables = default;

    private void Awake()
    {
        if (Player.Instance)
        {
            SetTarget();

            return;
        }

        Player.Inited += SetTarget;
    }

    private void OnDestroy()
    {
        Player.Inited -= SetTarget;
    }

    private void SetTarget()
    {
        Player.Inited -= SetTarget;

        foreach (TargetDependent targetable in targetables)
        {
            targetable.SetTarget(Player.Instance.transform);
        }
    }
}
