using ModuleBallistics;
using UnityEngine;

/// <summary>
/// Gun projectile on hit behaviour
/// </summary>
public class GunProjectileOnHitBehavior : MonoBehaviour
{
    [SerializeField] private AbstractProjectile projectile;

    private void OnHit(Collider collider)
    {
        //TODO: Change to more "Player" component as posible
        //and dont use tags
        if (collider.TryGetComponent(out WalkProvider input) == false)
        {
            projectile.IsActive = false;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        OnHit(collider);
    }
}
