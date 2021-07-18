using ModuleBallistics;
using UnityEngine;

/// <summary>
/// Data of projectile with simple ballistic and raycast hit check
/// </summary>
[CreateAssetMenu(fileName = "GunProjectileData", menuName = "Projectiles/GunProjectile")]
public class GunProjectileData : AbstractProjectileData
{
    [SerializeField] protected float startForce = default;

    /// <summary>
    /// Speed
    /// </summary>
    public float StartForce => startForce;

    [Range(0, 9999)]
    [SerializeField] protected int damage;
    public int Damage => damage;
}