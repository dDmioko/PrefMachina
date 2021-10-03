using System;
using UnityEngine;

/// <summary>
/// Stupid mark for player
/// </summary>
public class Player : MonoBehaviour
{
    public static event Action Inited;

    private static Player instance = null;
    public static Player Instance => instance;

    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);

            return;
        }

        instance = this;

        Inited?.Invoke();
    }

    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }
}
