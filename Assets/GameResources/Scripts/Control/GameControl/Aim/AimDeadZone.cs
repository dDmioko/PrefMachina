using UnityEngine;

/// <summary>
/// Inpute dead zone for aiming
/// </summary>
public class AimDeadZone
{
    private const string MIN_DEAD_ZONE_KEY = "MinDeadZone";
    private const string MOUSE_MIN_DEAD_ZONE_KEY = "MouseMinDeadZone";

    private const float MIN_DEAD_ZONE_DEFAULT = 0.125f;
    private const float MOUSE_MIN_DEAD_ZONE_DEFAULT = 0.125f;

    private float MinDeadZone = 0.125f;
    private float MouseMinDeadZone = 0.125f;

    public AimDeadZone()
    {
        Init();
    }

    private void Init()
    {
        MinDeadZone = PlayerPrefs.GetFloat(MIN_DEAD_ZONE_KEY, MIN_DEAD_ZONE_DEFAULT);
        MouseMinDeadZone = PlayerPrefs.GetFloat(MOUSE_MIN_DEAD_ZONE_KEY, MOUSE_MIN_DEAD_ZONE_DEFAULT);        
    }

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
