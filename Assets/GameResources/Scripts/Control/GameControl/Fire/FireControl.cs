using ModuleBallistics;
using UnityEngine;

/// <summary>
/// Movement control
/// </summary>
[RequireComponent(typeof(FireInput))]
public class FireControl : MonoBehaviour
{
    [SerializeField] private FireInput input = default;

    [SerializeField] private AbstractGun gun = default;

    private void OnEnable()
    {
        input.StartFire += OnStartFire;
        input.StopFire += OnStopFire;
    }

    private void OnDisable()
    {
        input.StartFire -= OnStartFire;
        input.StopFire -= OnStopFire;
    }

    private void OnStartFire()
    {
        gun.StartFire();
    }

    private void OnStopFire()
    {
        gun.StopFire();
    }
}
