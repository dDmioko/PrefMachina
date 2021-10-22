using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// Simple spawner
/// </summary>
public class Spawner : MonoBehaviour
{
    [SerializeField]
    private new Collider collider = default;

    [SerializeField]
    private float radius = 1.5f;

    [SerializeField] private EntityAmountPair[] entities = default;

    [SerializeField] private SpawnTypes spawnType = default;
    [SerializeField] private float spawnDelay = default;

    [SerializeField]
    private Transform pool = default;

    private Coroutine coroutine = null;    

    private void OnEnable()
    {
        if (spawnType == SpawnTypes.OverTime)
        {
            coroutine = StartCoroutine(SpawnWithDelay());

            return;
        }

        InstantSpaawn();        
    }

	private void OnDisable()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
    }

	private void InstantSpaawn()
	{
        if (spawnType == SpawnTypes.Instant)
        {
            foreach (EntityAmountPair entityAmountPair in entities)
            {
                for (int i = 0; i < entityAmountPair.Amount; ++i)
                {
                    Instantiate(entityAmountPair.entity.Prefab, transform.position, transform.rotation, pool);
                }
            }
        }
    }

    private IEnumerator SpawnWithDelay()
    {
        WaitForSeconds delay = new WaitForSeconds(spawnDelay);

        foreach (EntityAmountPair entityAmountPair in entities)
        {
            for (int i = 0; i < entityAmountPair.Amount; ++i)
            {
                yield return new WaitUntil(CheckIsSpaceFree);

                Collider instantiated = Instantiate(entityAmountPair.entity.Prefab, transform.position, transform.rotation, pool).GetComponent<Collider>();
                Physics.IgnoreCollision(instantiated, collider, true);

                yield return delay;
            }
        }
    }

    private bool CheckIsSpaceFree()
    {
        Collider[] hited = Physics.OverlapSphere(transform.position, radius);

        if (hited.Length == 0)
        {
            return true;
        }

        bool isObjectInZone = true;

        for (int i = 0; i < hited.Length; ++i)
        {
            if (hited[i].attachedRigidbody == false)
            {
                continue;
            }

            isObjectInZone = false;

            break;
        }        

        return isObjectInZone;
    }

    [Serializable]
    public struct EntityAmountPair
    {
        public SpawnEntity entity;

        [SerializeField]
        private AbstractGameValue amount;
        public int Amount => amount.Amount;

        public EntityAmountPair(SpawnEntity entity, int amount)
        {
            this.entity = entity;
            this.amount = new AbstractGameValue(amount);
        }
    }

    public enum SpawnTypes
    {
        Instant,
        OverTime
    }
}
