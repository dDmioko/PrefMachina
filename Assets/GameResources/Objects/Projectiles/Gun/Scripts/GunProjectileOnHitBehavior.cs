using ModuleBallistics;
using UnityEngine;

/// <summary>
/// Gun projectile on hit behaviour
/// </summary>
public class GunProjectileOnHitBehavior : MonoBehaviour
{
    [SerializeField] private GunProjectile projectile = default;

    private void OnHit(Collider collider)
    {
        if (collider.TryGetComponent(out AbstractTeamMark team) == false)
        {
            projectile.IsActive = false;
            return;
        }

        if (projectile.Team.GetType() != team.GetType())
        {
            projectile.IsActive = false;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        OnHit(collider);
    }
}
