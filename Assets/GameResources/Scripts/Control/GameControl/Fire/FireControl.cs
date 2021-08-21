using ModuleBallistics;
using UnityEngine;

/// <summary>
/// Movement control
/// </summary>
[RequireComponent(typeof(FireInput))]
public class FireControl : MonoBehaviour
{
    [SerializeField] private FireInput input = default;

    [SerializeField] private SimpleGun gun = default;

    private void OnEnable()
    {
        input.Fire += OnFire;
    }

    private void OnDisable()
    {
        input.Fire -= OnFire;
    }

    private void OnFire()
    {
        gun.StartFire();
    }
}
