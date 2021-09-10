using UnityEngine;

/// <summary>
/// Health
/// </summary>
[DisallowMultipleComponent]
public class Health : DamageTaker
{        
    public override Damage TakeDamage(Damage damage)
    {
        if (damage.Amount <= 0)
        {
            return damage;
        }        

        Amount -= damage.Amount;        

        InvokeAmountChanged(Amount, -damage.Amount);        

        return new Damage(0);
    }

    public override void Heal(Heal heal)
    {
        if (heal.Amount <= 0)
        {
            return;
        }
        
        Amount += heal.Amount;        

        InvokeAmountChanged(Amount, heal.Amount);        
    }
}
