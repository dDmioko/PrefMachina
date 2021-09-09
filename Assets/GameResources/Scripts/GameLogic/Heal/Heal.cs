using System;

/// <summary>
/// Heal
/// </summary>
[Serializable]
public struct Heal
{
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

    public Heal(int amount)
    {
        this.amount = amount > 0 ? amount : 0;
    }
}
