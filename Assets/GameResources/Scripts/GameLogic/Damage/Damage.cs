using System;
using UnityEngine;

/// <summary>
/// Damage
/// </summary>
[Serializable]
public struct Damage
{
    [SerializeField]
    private int amount;
    public int Amount
    {
        get
        {
            return amount;
        }

        set
        {
            amount = value < 0 ? 0 : value;
        }
    }

    public Damage(int amount)
    {
        this.amount = amount > 0 ? amount : 0;        
    }
}
