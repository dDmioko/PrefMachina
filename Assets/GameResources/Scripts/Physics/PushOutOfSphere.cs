using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Push object out of sphere area
/// </summary>
public class PushOutOfSphere : MonoBehaviour
{
    [SerializeField]
    private new Collider collider = default;

    [SerializeField]
    private float radius = 1.5f;

    [SerializeField]
    private float pushOutPower = 15f;

    private Coroutine coroutine = null;

    private List<Collider> objects = new List<Collider>();

    private int i = 0;

    private void FixedUpdate()
    {
        if (i < 2)
        {
            ++i;

            return;
        }

        i = 0;

        Check();
    }

    private void Check()
    {
        Collider[] hited = Physics.OverlapSphere(transform.position, radius);

        if (hited.Length == 0)
        {
            return;
        }

        for (int i = 0; i < hited.Length; ++i)
        {
            if (hited[i].attachedRigidbody == null)
            {
                continue;
            }

            if (objects.Contains(hited[i]) == false)
            {
                if (collider)
                {
                    Physics.IgnoreCollision(hited[i], collider, true);
                }

                objects.Add(hited[i]);
            }
        }

        if (coroutine == null && objects.Count > 0)
        {
            coroutine = StartCoroutine(Push());
        }
    }

    private IEnumerator Push()
    {
        while (objects.Count > 0)
        {
            for (int i = 0; i < objects.Count;)
            {
                if (objects[i].gameObject.activeSelf == false || Vector3.Distance(transform.position, objects[i].transform.position) > radius)
                {
                    if (collider)
                    {
                        Physics.IgnoreCollision(objects[i], collider, false);
                    }

                    objects.RemoveAt(i);

                    continue;
                }

                objects[i].attachedRigidbody.AddForce(objects[i].attachedRigidbody.mass * pushOutPower * transform.forward);

                ++i;
            }

            yield return new WaitForFixedUpdate();
        }

        coroutine = null;
    }
}
