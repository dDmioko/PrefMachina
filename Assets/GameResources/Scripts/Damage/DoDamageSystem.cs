using UnityEngine;

public class DoDamageSystem : EcsSystemWrapper
{    
    //private EcsFilter<Health, Damage> _filter = null;

    public void Run()
    {
        //foreach (var i in _filter)
        //{
        //    ref EcsEntity entity = ref _filter.GetEntity(i);

        //    ref Health health = ref _filter.Get1(i);
        //    ref Damage damage = ref _filter.Get2(i);

        //    Debug.Log(health.amount + " " + damage.Amount);

        //    health.amount -= damage.Amount;

        //    entity.Del<Damage>();            
        //}
    }
}
