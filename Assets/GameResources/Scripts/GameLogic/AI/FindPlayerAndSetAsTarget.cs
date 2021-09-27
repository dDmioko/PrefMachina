using UnityEngine;

/// <summary>
/// Set player as target to components
/// </summary>
public class FindPlayerAndSetAsTarget : MonoBehaviour
{
    [SerializeField]
    private Targetable[] targetables = default;

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

        foreach (Targetable targetable in targetables)
        {
            targetable.SetTarget(Player.Instance.transform);
        }
    }
}
