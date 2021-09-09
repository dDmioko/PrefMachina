/// <summary>
/// Health
/// </summary>
public class Health : DamageTaker
{        
    public override Damage TakeDamage(Damage damage)
    {
        if (damage.Amount <= 0)
        {
            return damage;
        }

        Damage restDamage = new Damage(damage.Amount - Amount);

        Amount -= damage.Amount;        

        InvokeAmountChanged(Amount, -damage.Amount);        

        return restDamage;
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

    public override void Regenerate(Heal heal)
    {
        if (heal.Amount <= 0)
        {
            return;
        }

        Amount += heal.Amount;        

        InvokeAmountChanged(Amount, heal.Amount);
    }
}
