using System;
using UnityEngine;

/// <summary>
/// Disable object
/// </summary>
public class Death : MonoBehaviour
{
    public event Action Died;

    [SerializeField] private Health health = default;

    private void OnEnable()
    {
        health.AmountChanged += OnHealthChanged;
    }

    private void OnHealthChanged(int amount, int difference)
    {
        if (amount > 0)
        {
            return;            
        }

        Died?.Invoke();

        gameObject.SetActive(false);
    }
}