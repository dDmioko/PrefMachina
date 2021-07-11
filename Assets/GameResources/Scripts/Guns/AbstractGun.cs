using UnityEngine;
using ModuleBallistics;

/// <summary>
/// Abstract gun
/// </summary>
public abstract class AbstractGun : MonoBehaviour, IGun
{
    public virtual void Fire() {}
}
