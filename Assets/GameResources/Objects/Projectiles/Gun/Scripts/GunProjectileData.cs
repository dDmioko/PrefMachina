using ModuleBallistics;
using UnityEngine;

/// <summary>
/// Data of projectile with simple ballistic and raycast hit check
/// </summary>
[CreateAssetMenu(fileName = "GunProjectileData", menuName = "Projectiles/GunProjectile")]
public class GunProjectileData : AbstractProjectileData
{
    [SerializeField]
    private Damage damage = default;
    public Damage Damage => damage;

    [SerializeField]
    protected float startForce = default;    

    /// <summary>
    /// Speed
    /// </summary>
    public float StartForce { get => startForce; }
}