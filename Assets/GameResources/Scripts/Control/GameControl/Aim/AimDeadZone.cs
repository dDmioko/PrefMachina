using UnityEngine;

/// <summary>
/// Inpute dead zone for aiming
/// </summary>
public class AimDeadZone : MonoBehaviour
{
    [Range(0, 1f)]
    [SerializeField] private float MinDeadZone = 0.125f;

    [Range(0, 1f)]
    [SerializeField] private float MouseMinDeadZone = 0.125f;

    /// <summary>
    /// Check dead zone
    /// </summary>
    /// <param name="input">Input data</param>
    /// <param name="isMouse">Used device</param>
    /// <returns>Is dead zone?</returns>
    public bool Check(Vector2 input, bool isMouse)
    {
        if (isMouse)
        {
            return input.magnitude < MouseMinDeadZone;
        }

        return input.magnitude < MinDeadZone;
    }
}
