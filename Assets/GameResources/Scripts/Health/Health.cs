using System;
using UnityEngine;

/// <summary>
/// Health
/// </summary>
public class Health : MonoBehaviour
{
    /// <summary>
    /// returns Health amount and difference
    /// </summary>
    public event Action<int, int> AmountChanged;    

    [SerializeField] private int amount;
    public int Amount => amount;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="damage"></param>
    public void DoDamage(Damage damage)
    {
        if (damage.amount <= 0)
        {
            return;
        }

        amount -= damage.amount;
        
        AmountChanged?.Invoke(amount, damage.amount);
    }
}
